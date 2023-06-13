using TMPro;
using UnityEngine;

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

    public void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo )
    { this.buffCode = buffCode; _CardInfo = cardInfo; }

    //card generate
    public override void Init()
    {
        //자식들이 동적으로 변하지 않으니까 이 부분은 start에서 파싱해두자.
        if (this.transform.GetChild(0).GetChild(1)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmp))
        {
            tmp.text = cardInfo.BuffEnumName;
        }
        else
        {
            Debug.LogError("Not Setted Object You're null!!");
        }
        

        //this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = cardInfo.BuffEnumName;
        //this.transform.GetChild(2).GetComponent<TextMeshPro>().text = cardInfo.information;
        //this.transform.GetChild(3).GetComponent<TextMeshPro>().text = cardInfo.description;

        //this.GetComponent<Image>().sprite = JsonUtility.FromJson()cardInfo.BGImage;
        //this.GetComponent<Image>().sprite = cardInfo.FRImage;
        //data = buffManager.SetBuffData(buffCode, stat);
        //Debug.Log(stat);
    }
}
