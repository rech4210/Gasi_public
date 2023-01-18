using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : Buff
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
        //Debug.Log($"데미지 증가{point}");
    }

    public override void BuffUse()
    {
        Debug.Log("더미입니다");
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
