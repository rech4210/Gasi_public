using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAttack : MonoBehaviour, ISetCardInfo,ICardSkill
{
    protected int skillCheckNum = 100;

    protected AttackGenerator attackGenerator;

    char attackCode;
    AttackType attackType;
    AttackStatus attackStatus;
    AttackCardInfo attackInfo;
    public AttackCardInfo _AttackCardInfo { get { return attackInfo; }}
    public AttackStatus _AttackStatus { get { return attackStatus; }}

    //use when checked
    // 이 함수에서 버프매니저를 최신화 시켜줘야하지 않을까?
    public abstract void OnChecked();

    

    protected void FindAttackGenerator(AttackGenerator attackGenerator)
    {
        try
        {
            if (GameObject.FindWithTag("AttackGenerator")
            .TryGetComponent<AttackGenerator>(out AttackGenerator attack))
            {
                this.attackGenerator = attack;
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"에러 대상:{this.name}$에러 내용: {e.Message}");
            throw e;
        }
    }
    //이거 잘 적용되는지 확인해봐야함.
    public virtual void GetRandomCodeWithInfo(char _attackCode, AttackCardInfo _cardInfo, AttackStatus _attackStatus)
    { this.attackCode = _attackCode; attackInfo = _cardInfo; this.attackStatus = _attackStatus; }

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


        if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
        {

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine("AttackCardResource/", attackInfo.fRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{attackInfo.fRImage} at: " + Path.Combine(Application.dataPath + "/AttackCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("AttackCardResource/", attackInfo.bGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{attackInfo.bGImage} at: " + Path.Combine(Application.dataPath + "/AttackCardResource/", ""));
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
        switch (_AttackCardInfo.attackCardEnum)
        {
            case AttackCardEnum.skill_1:
                attackGenerator.UseSkill(_AttackStatus, "skill_1");
                break;
            case AttackCardEnum.skill_2:
                attackGenerator.UseSkill(_AttackStatus, "skill_2");
                break;
            case AttackCardEnum.skill_3:
                attackGenerator.UseSkill(_AttackStatus, "skill_3");
                break;
            default:
                break;
        }
    }
}
