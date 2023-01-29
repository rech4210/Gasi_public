using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : AttackGenerater
{
    private void Start()
    {
        attackStatus = new AttackStatus(1,10,6f,1f);
        Debug.Log($"현재 대상의 태그는 {GetAttackType()} + {duration}");
    }

    AttackType attackType = AttackType.laser;
    public override AttackType GetAttackType()
    {
        return attackType;
    }

    public override void AttackDamage()
    {
    }

    public override void AttackDuration()
    {
    }

    public override void AttackRange()
    {
    }

    public void DoubleLaser()
    {

    }
}
