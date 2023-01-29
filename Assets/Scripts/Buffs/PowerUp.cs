using UnityEngine;

public class PowerUp : StatusEffect, IBuff
{
    BuffStorage type = BuffStorage.Power;
    BuffStat status;
    BuffData data;
    private void Start()
    {
        FindBuffManager(buffManager);
        Debug.Log("생성되었습니다");
        Init();
    }

    public override void OnChecked()
    {
        buffManager.AddorUpdateDictionary(type, data);
    }

    public override void BuffUp()
    {
        RankUp();
        base.point = 5;
        Debug.Log($"데미지 증가{point}");
    }

    public override void BuffUse()
    {
        base.point = 15;
        status.point = point;
        Debug.Log($"버프 최초 사용 : {this.GetType()}");
    }
    public override void RankUp()
    {
        rank++;
        status.rank  = rank;
        Debug.Log($"랭크 상승 :{rank}");
    }

    public override void Init()
    {
        data = new BuffData(this,status);
        //포인트와 랭크 초기화
    }

}
