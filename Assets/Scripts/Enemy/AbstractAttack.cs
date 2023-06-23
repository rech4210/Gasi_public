using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour, ISetCardInfo
{
    char attackCode;
    AttackType attackType;
    private AttackStatus attackStatus;
    private AttackCardInfo attackInfo;
    public AttackCardInfo _attackInfo { get { return attackInfo; }}

    public AttackStatus _attackStatus { get {return attackStatus ;} set { SetAttackStatus(value); }}

    public abstract void OnChecked();


    public virtual void GetRandomCodeWithInfo(char attackCode, AttackCardInfo cardInfo)
    { this.attackCode = attackCode; attackInfo = cardInfo; }
    //public override void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo)
    //{ this.buffCode = buffCode; _CardInfo = cardInfo; }
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

    public abstract void SetCardInfo();
}
