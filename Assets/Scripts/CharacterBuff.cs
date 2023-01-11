using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuff : Buff
{
    public BuffManager buffmanager;


    public override void OnChecked()
    {
        buffmanager.GetBuff(this);
    }
    
    public override void BuffUp()
    {
        base.point = 5;
        Debug.Log($"데미지 증가{point}");
    }

    public override void BuffUse()
    {
        base.point = 15;
        Debug.Log($"버프 최초 사용{point}");
        buffmanager.GetBuff(this);
    }
}
