using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : StatusEffect/*, IBuff*/
{
    // Card Generate -> search BuffContainer -> add buffcode in card
    // -> click ->  
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
        buffManager.AddorUpdateDictionary(_BuffCode);
        // 여기에 연산하는 기능?
    }

    //public override void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo, BuffStat buffStat )
    //{ base.GetRandomCodeWithInfo(); }

    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
}
