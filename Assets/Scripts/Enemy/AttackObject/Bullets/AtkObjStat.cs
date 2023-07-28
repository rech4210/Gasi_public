using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkObjStat : MonoBehaviour
{
    protected float speed;
    protected float point;
    protected float duration;
    protected float scale;


    public float Point { get { return point;} }
    public void GetAtkObjPoint(AttackStatus attackStatus)
    {
        this.point = attackStatus.point;
        this.speed = attackStatus.speed;
        
        //속도도 관리해줘야함
    }
}
