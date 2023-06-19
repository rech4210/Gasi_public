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
    CardInfo _CardInfo
    { /*호버 정보표기*/ get { return cardInfo; }
      /*카드 변화 리플렉션*/ set { cardInfo = value; Init(); } }

    //BuffStat stat; // 각 카드가 data를 가지고 있어서 생기는 문제임 그냥. -> 버프 매니저에서 일괄적으로 버프 상태를 관리하도록 해야함.
    //BuffData data;

    private void Start()
    {
        FindBuffManager(buffManager);
    }
    public override void OnChecked()
    {
        Debug.Log("온체크 발동");
        buffManager.AddorUpdateDictionary(buffCode);
    }

    public override void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo )
    { this.buffCode = buffCode; _CardInfo = cardInfo; }

    //card generate
    public override void Init()
    {
        //자식들이 동적으로 변하지 않으니까 이 부분은 start에서 파싱해두자.
        if (this.transform.GetChild(0).GetChild(1)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI buffname))
        {
            buffname.text = cardInfo.BuffEnumName;
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

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine("CardResource/", cardInfo.FRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.FRImage} at: " + Path.Combine(Application.dataPath + "/CardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("CardResource/", cardInfo.BGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.BGImage} at: " + Path.Combine(Application.dataPath + "/CardResource/", ""));
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
