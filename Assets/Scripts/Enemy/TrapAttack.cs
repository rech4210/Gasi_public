
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TrapAttack : AbstractAttack, IUseSkill
{

    AttackType attackType = AttackType.trap;
    public override void OnChecked()
    {
        throw new System.NotImplementedException();
    }

    public void Skill_1()
    {
        throw new System.NotImplementedException();
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
    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
}
