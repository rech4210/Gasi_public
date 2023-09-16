using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAttack : MonoBehaviour, ISetCardInfo, ICardSkill
{
    protected int skillCheckNum = 100;

    protected AttackGenerator attackGenerator;
    protected BuffManager buffManager;// delete

    protected char attackCode;
    protected AttackData attackData;
    protected AttackStatus attackStatus;
    protected AttackCardInfo attackInfo;
    public AttackData _AttackData { get { return attackData; } }

    //use when checked
    // 이 함수에서 버프매니저를 최신화 시켜줘야하지 않을까?
    public abstract void OnChecked();

    

    protected void FindBuffWithAttackGenerator()
    {
        try
        {
            if (GameObject.FindWithTag("AttackGenerator")
            .TryGetComponent(out AttackGenerator attack))
            {
                this.attackGenerator = attack;
            }
            if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent(out BuffManager buff))
            {
                this.buffManager = buff;
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"에러 대상:{this.name}$에러 내용: {e.Message}");
            throw e;
        }
    }
    //이거 잘 적용되는지 확인해봐야함.
    // is here updated?
    public virtual void GetRandomCodeWithInfo(AttackData data)
    { this.attackCode = data.attackCode; attackData = data; attackInfo = data.attackInfo; attackStatus = data.attackStatus; }

    // 스탯타입으로 결정하지말고 차라리 함수가 편할 수도 있음. json에 스탯 타입까지 명시한다면 귀찮아질것.
    public virtual void CalcAttackStatus(float calcNum, string statType)
    {

        this.attackStatus.rank++;
        switch (statType)
        {
            case "duration":
                this.attackStatus.duration *= calcNum; break;
            case "point":
                this.attackStatus.point += (int)calcNum; break;
            case "scale":
                this.attackStatus.scale *= calcNum; break;
            default:
                break;
        }
    }

    
    public virtual void SetCardInfo()
    {
        if (this.transform.GetChild(0).GetChild(1)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI buffname))
        {
            buffname.text = attackInfo.attackName;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(2)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI information))
        {
            information.text = attackInfo.information;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(3)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
        {
            description.text = attackInfo.description;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(4)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI rank))
        {
            rank.text = ""+attackStatus.rank;
        }
        else Debug.LogError("Not Setted Object You're null!!");


        if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
        {

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine(StringManager.Instance.attackCardResource, attackInfo.fRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{attackInfo.fRImage} at: " + Path.Combine(Application.dataPath + $"/{StringManager.Instance.attackCardResource}", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine(StringManager.Instance.attackCardResource, attackInfo.bGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{attackInfo.bGImage} at: " + Path.Combine(Application.dataPath + $"/{StringManager.Instance.attackCardResource}", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child backImage");
        }
        //this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = cardInfo.BuffEnumName;
        //this.transform.GetChild(2).GetComponent<TextMeshPro>().text = cardInfo.information;
        //this.transform.GetChild(3).GetComponent<TextMeshPro>().text = cardInfo.description;

        //this.GetComponent<Image>().sprite = cardInfo.FRImage;
        //data = buffManager.SetBuffData(buffCode, stat);
        //Debug.Log(stat);
    }

    public void Skill()
    {
        switch (attackInfo.attackCardEnum)
        {
            case AttackCardEnum.skill_1:
                attackGenerator.UseSkill(attackStatus, "skill_1");
                break;
            case AttackCardEnum.skill_2:
                attackGenerator.UseSkill(attackStatus, "skill_2");
                break;
            case AttackCardEnum.skill_3:
                attackGenerator.UseSkill(attackStatus, "skill_3");
                break;
            default:
                break;
        }
    }
}
