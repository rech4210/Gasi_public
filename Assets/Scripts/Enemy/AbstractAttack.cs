using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAttack : MonoBehaviour, ISetCardInfo
{
    char attackCode;
    AttackType attackType;
    private AttackStatus attackStatus;
    private AttackCardInfo attackInfo;
    public AttackCardInfo _attackInfo { get { return attackInfo; }}

    //public AttackStatus _attackStatus { get {return attackStatus ;} set { SetAttackStatus(value); }}

    //use when checked
    // 이 함수에서 버프매니저를 최신화 시켜줘야하지 않을까?
    public abstract void OnChecked();


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
            buffname.text = _attackInfo.attackName;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(2)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI information))
        {
            information.text = _attackInfo.information;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(3)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
        {
            description.text = _attackInfo.description;
        }
        else Debug.LogError("Not Setted Object You're null!!");


        if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
        {

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine("AttackCardResource/", _attackInfo.fRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{_attackInfo.fRImage} at: " + Path.Combine(Application.dataPath + "/AttackCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("AttackCardResource/", _attackInfo.bGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{_attackInfo.bGImage} at: " + Path.Combine(Application.dataPath + "/AttackCardResource/", ""));
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
}
