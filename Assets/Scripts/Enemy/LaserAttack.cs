
using UnityEngine;

public class LaserAttack : AbstractAttack
{
    
    public void Start()
    {
        FindBuffWithAttackGenerator();
    }
    // 온체크시 버프 매니저에게 영향을 줘야함.수정? 어택 제너레이터에서 해야할듯.
    public override void OnChecked()
    {
        if ((int)_AttackCardInfo.attackCardEnum > skillCheckNum)
        {
            Skill();
        }
        else if (_AttackCardInfo.attackCardEnum == AttackCardEnum.generate)
        {
            attackGenerator?.Generate(_AttackStatus);
        }
        // 조건 바꿔야할듯? 수정
        else if((int)_AttackCardInfo.attackCardEnum < skillCheckNum)
        {
            attackGenerator.IncreaseTargetStat(_AttackStatus, _AttackCardInfo);
        }
        buffManager.AddorUpdateAttackDictionary(attackCode, _AttackStatus);


        this.gameObject.SetActive(false);
    }

    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
    //public override void SetCardInfo()
    //{
    //    if (this.transform.GetChild(0).GetChild(1)
    //        .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI buffname))
    //    {
    //        buffname.text = _attackInfo.attackName;
    //    }
    //    else Debug.LogError("Not Setted Object You're null!!");

    //    if (this.transform.GetChild(0).GetChild(2)
    //        .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI information))
    //    {
    //        information.text = _attackInfo.information;
    //    }
    //    else Debug.LogError("Not Setted Object You're null!!");

    //    if (this.transform.GetChild(0).GetChild(3)
    //        .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
    //    {
    //        description.text = _attackInfo.description;
    //    }
    //    else Debug.LogError("Not Setted Object You're null!!");


    //    if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
    //    {

    //        frontImage.sprite = Resources.Load<Sprite>(Path.Combine("CardResource/", _attackInfo.fRImage));
    //        if (frontImage.sprite == null)
    //        {
    //            Debug.Log($"There is no resource__{_attackInfo.fRImage} at: " + Path.Combine(Application.dataPath + "/CardResource/", ""));
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("wrong Path in child frontImage");
    //    }

    //    if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
    //    {

    //        backImage.sprite = Resources.Load<Sprite>(Path.Combine("CardResource/", _attackInfo.bGImage));
    //        if (backImage.sprite == null)
    //        {
    //            Debug.Log($"There is no resource__{_attackInfo.bGImage} at: " + Path.Combine(Application.dataPath + "/CardResource/", ""));
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("wrong Path in child backImage");
    //    }
    //    //this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = cardInfo.BuffEnumName;
    //    //this.transform.GetChild(2).GetComponent<TextMeshPro>().text = cardInfo.information;
    //    //this.transform.GetChild(3).GetComponent<TextMeshPro>().text = cardInfo.description;

    //    //this.GetComponent<Image>().sprite = cardInfo.FRImage;
    //    //data = buffManager.SetBuffData(buffCode, stat);
    //    //Debug.Log(stat);
    //}
}
