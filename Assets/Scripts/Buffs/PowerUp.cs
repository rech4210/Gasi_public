using UnityEngine;
public class PowerUp : StatusEffect, IBuff
{
    BuffEnumStorage type = BuffEnumStorage.Power;
    BuffData data; // 각 카드가 data를 가지고 있어서 생기는 문제임 그냥. -> 버프 매니저에서 일괄적으로 버프 상태를 관리하도록 해야함.
    private void Start()
    {
        if (data.StatusEffect == null)
        {
            FindBuffManager(buffManager);
            Init();
        }
    }
    public override void OnChecked()
    {
        buffManager.AddorUpdateDictionary(type, data);
    }
     // -> 버프를 각각 개체에서 관리하는게 아닌, 버프매니저의 contains 키로 모으기
    public override BuffData BuffUp()
    {
        data.stat.rank++;
        data.stat.point += data.stat.upValue;
        return data;
    }

    public override BuffData BuffUse()
    {
        data.stat.point += data.stat.useValue;
        return data;
    }

    public override void Init()
    {
        data.StatusEffect = this;
        data = buffManager.SetBuffData(type,data);
        Debug.Log(this.data.StatusEffect+"  " + data.stat);
    }

}
