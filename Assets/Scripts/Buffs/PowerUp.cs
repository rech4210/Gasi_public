using UnityEngine;
public class PowerUp : StatusEffect/*, IBuff*/
{
    // Card Generate -> search BuffContainer -> add buffcode in card
    // -> click ->  
    char buffCode;
    //BuffStat stat; // 각 카드가 data를 가지고 있어서 생기는 문제임 그냥. -> 버프 매니저에서 일괄적으로 버프 상태를 관리하도록 해야함.
    //BuffData data;
    private void Start()
    {
        //if (data.StatusEffect == null)
        //{
        //}
            FindBuffManager(buffManager);
    }
    public override void OnChecked()
    {
        buffManager.AddorUpdateDictionary(buffCode);
    }
     // -> 버프를 각각 개체에서 관리하는게 아닌, 버프매니저의 contains 키로 모으기

    public void GetRandomBuffCode(char buffCode)
    { this.buffCode = buffCode;}

    //card generate
    public override void Init()
    {
        //data = buffManager.SetBuffData(buffCode, stat);
        //Debug.Log(stat);
    }
}
