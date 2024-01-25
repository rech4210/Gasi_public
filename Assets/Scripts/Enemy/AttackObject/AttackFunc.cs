using System;
using System.ComponentModel;
using UnityEngine;

public abstract class AttackFunc<T> : MonoBehaviour, ITimeEvent where T : AttackFunc<T>
{
    AttackCardInfo attackInfo;
    AttackStatus attackStatus;

    public void Initalize(AttackStatus status, AttackCardInfo info, GameObject attackTarget)
    {
        _Player = attackTarget;
        _AttackStatus = status;
        _AttackCardInfo = info;
        CalcStat(status,info);
    }

    protected bool sk_1 = false;
    protected bool sk_2 = false;
    protected bool sk_3 = false;

    [SerializeField] protected GameObject attackObject;
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //var rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        //Gizmos.matrix = rotationMatrix;
        Gizmos.DrawRay(this.transform.position, _Player.transform.position - transform.position);
    }

    public AttackCardInfo _AttackCardInfo { get => attackInfo; set => attackInfo = value; }
    public AttackStatus _AttackStatus { get => attackStatus; set => attackStatus = value; }

    public int _Point { protected get { return attackStatus.point; } set { attackStatus.point = value; } }
    public float _Duration { protected get { return attackStatus.duration; } set { attackStatus.duration = value; } }
    public float _Scale { protected get { return attackStatus.scale; } set { attackStatus.scale = value; } }
    public float _Speed { protected get { return attackStatus.speed; } set { attackStatus.speed = value; } }
    public int _Rank { protected get { return attackStatus.rank; } set { attackStatus.rank = value; } }


    [SerializeField] private GameObject player;
    public GameObject _Player { protected get { return player; } set { player = value; } }

    // 이거 분리해야함.
    public abstract void CalcStat(AttackStatus status, AttackCardInfo info);

    public virtual Quaternion ChaseTarget(GameObject player, GameObject target)
    {
        return Quaternion.LookRotation(player.transform.position - target.transform.position);
    }

    protected abstract void ExcuteAttack();

    protected virtual void OnHited()
    {
        _Player.GetComponent<PlayerData>();
    }

    //public abstract ITimeEvent TimeEvent();

    public abstract void TimeEvent(float time);


    public void SetSkillBool(int i)
    {
        switch (i)
        {
            case 0: sk_1 = true; break;
            case 1: sk_2 = true; break;
            case 2: sk_3 = true; break;
            /*            case 2: sk_3 = true; break;
                        case 2: sk_3 = true; break;*/
            default:
                break;
        }
    }

    public void DeadAction(Action action) { turretAction += action; }

    private Action turretAction;

}
