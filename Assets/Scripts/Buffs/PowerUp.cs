using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : StatusEffect/*, IBuff*/
{
    // Card Generate -> search BuffContainer -> add buffcode in card
    // -> click ->  
    char buffCode;
    CardInfo cardInfo;
    BuffStat buffStat;

    //CardInfo _CardInfo
    //{ /*호버 정보표기*/ get { return cardInfo; }
    //  /*카드 변화 리플렉션*/ set { cardInfo = value; Init(); } }


    private void Start()
    {
        FindBuffManager(buffManager);
    }
    public override void OnChecked()
    {
        Debug.Log("온체크 발동");
        buffManager.AddorUpdateDictionary(buffCode);
        // 여기에 연산하는 기능?
    }

    public override void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo, BuffStat buffStat )
    { this.buffCode = buffCode; this.cardInfo = cardInfo; this.buffStat = buffStat; }

    public override void SetCardInfo()
    {
        //자식들이 동적으로 변하지 않으니까 이 부분은 start에서 파싱해두자.
        if (this.transform.GetChild(0).GetChild(1)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI buffname))
        {
            buffname.text = cardInfo.cardName;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(2)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI information))
        {
            information.text = cardInfo.information;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(3)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
        {
            description.text = cardInfo.description;
        }
        else Debug.LogError("Not Setted Object You're null!!");


        if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
        {

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine("BuffCardResource/", cardInfo.fRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.fRImage} at: " + Path.Combine(Application.dataPath + "/BuffCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("BuffCardResource/", cardInfo.bGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.bGImage} at: " + Path.Combine(Application.dataPath + "/BuffCardResource/", ""));
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
