using UnityEngine;

public class CharacterBuff : StatusEffect,IBuff
{
    BuffEnumStorage type = BuffEnumStorage.Health;
    BuffData data;
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
        data = buffManager.SetBuffData(type, data);
        Debug.Log(this.data.StatusEffect + "  " + data.stat);
    }
}
