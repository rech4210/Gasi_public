using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    private AttackStatus attackStatus;

    public AttackStatus _attackStatus { get {return attackStatus ;} set { SetAttackStatus(value); }}
    //public int rank
    //{ get { return attackStatus.rank; } set { attackStatus.rank += value; }}
    //public int point
    //{ get { return attackStatus.point; } set { attackStatus.point = value; } }
    //public float duration
    //{ get { return attackStatus.duration; } set { attackStatus.duration= value; } }
    //public float scale
    //{ get { return attackStatus.scale; } set { attackStatus.scale = value; } }

    public abstract AttackType GetAttackType();

    public virtual void SetAttackStatus(AttackStatus attackStatus)
    {
        _attackStatus = attackStatus;
    }

    // 스탯타입으로 결정하지말고 차라리 함수가 편할 수도 있음. json에 스탯 타입까지 명시한다면 귀찮아질것.
    public virtual void CalcAttackStatus(float calcNum, string statType)
    {
        this.attackStatus.rank++;
        switch (statType)
        {
            case "duration":
                this.attackStatus.duration *= calcNum; break;
            case "point":
                this.attackStatus.point += (int)calcNum; break;
            case "scale":
                this.attackStatus.scale *= calcNum; break;
            default:
                break;
        }
    }
}
