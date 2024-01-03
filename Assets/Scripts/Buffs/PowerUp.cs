using System.IO;

public class PowerUp : StatusEffect/*, IBuff*/
{
    //CardInfo _CardInfo
    //{ /*호버 정보표기*/ get { return cardInfo; }
    //  /*카드 변화 리플렉션*/ set { cardInfo = value; Init(); } }


    private void Start()
    {
        FindBuffManager(buffManager);
    }
    public override void OnChecked()
    {
        //Debug.Log("온체크 발동");
        //generate 받아야 함 9/29

        //_BuffCode = '0';
        buffManager.AddorUpdateDictionary(_BuffCode);
        var stat = DataManager.Instance._playerStat;
        stat.health ++;
        DataManager.Instance.PlayerStatDele.Invoke(stat);
        // 여기에 연산하는 기능?
    }


    //public override void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo, BuffStat buffStat )
    //{ base.GetRandomCodeWithInfo(); }

    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
}
