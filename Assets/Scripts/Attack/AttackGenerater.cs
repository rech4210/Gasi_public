using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AttackGenerater : MonoBehaviour
{
    BuffEnumStorage buff;
    AttackType attckType;
    public AttackStatus attackStatus;
    public int rank
    { get { return attackStatus.rank; } set { attackStatus.rank += value; }}
    public int point
    { get { return attackStatus.point; } private set { attackStatus.point = value; } }
    public float duration
    { get { return attackStatus.duration; } set { attackStatus.duration= value; } }
    public float scale
    { get { return attackStatus.scale; } set { attackStatus.scale = value; } }

    public abstract void AttackDamage();

    public abstract void AttackDuration();

    public abstract void AttackRange();

    public abstract AttackType GetAttackType();

    public virtual void Generater(AttackGenerater attackObj)
    {
        buff = BuffEnumStorage.Health;
    }
}
