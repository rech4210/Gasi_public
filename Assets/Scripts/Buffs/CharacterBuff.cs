using UnityEngine;

public class CharacterBuff : StatusEffect,IBuff
{
    BuffStorage type = BuffStorage.Health;
    BuffData data;
    BuffStat stat;
    private void Start()
    {
        FindBuffManager(buffManager);
        Init();
    }

    public override void OnChecked()
    {
        buffManager.AddorUpdateDictionary(type, data);
    }
    public override void Init()
    {
        data = buffManager.SetBuffData(this);
        stat = new BuffStat(data.stat.rank, data.stat.point, data.stat.useValue, data.stat.upValue);
    }
    public override void BuffUse()
    {
        stat.point += stat.useValue;
    }

    public override void BuffUp()
    {
        RankUp(); // 랭크업 부분도 매니저에서 처리할것.
        stat.point += stat.upValue;
        Debug.Log(stat.point);
    }

    public override void RankUp()
    {
        rank++; // 랭크업에 따른 상승폭 증가 구현 가능.
        Debug.Log($"랭크 상승 :{rank}");
    }
}
