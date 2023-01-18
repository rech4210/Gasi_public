using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Buff
{

    private void Start()
    {
        FindBuffManager(buffManager);
        Init();
    }

    public override void OnChecked()
    {
        buffManager.GetBuff(this);
    }
    
    public override void BuffUp()
    {
        base.point = 5;
        Debug.Log($"데미지 증가{point}");
    }

    public override void BuffUse()
    {
        base.point = 15;
        Debug.Log($"버프 최초 사용 : {this.GetType()}");
    }

    public override void Init()
    {
       
    }

    public override void RankUp(int rank)
    {
        base.rank = rank;
    }
    public override void BuffDown()
    {
        Debug.Log($"버프 감소 : {this.GetType()}");
    }
}
