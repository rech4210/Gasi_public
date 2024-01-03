using UnityEngine;

public abstract class AttackFunc : MonoBehaviour, IUseSkill, ITimeEvent
{
    AttackType attackType;
    AttackStatus attackStatus;

    [SerializeField] protected GameObject attackObject;
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //var rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        //Gizmos.matrix = rotationMatrix;
        Gizmos.DrawRay(this.transform.position, _Player.transform.position - transform.position);
    }

    public AttackType _AttackType { get => attackType; set => attackType = value; }
    public AttackStatus _AttackStatus { protected get => attackStatus; set => attackStatus = value; }

    public int _Point { protected get { return attackStatus.point; } set { attackStatus.point = value; } }
    public float _Duration { protected get { return attackStatus.duration; } set { attackStatus.duration = value; } }
    public float _Scale { protected get { return attackStatus.scale; } set { attackStatus.scale = value; } }
    public float _Speed { protected get { return attackStatus.speed; } set { attackStatus.speed = value; } }
    public int _Rank { protected get { return attackStatus.rank; } set { attackStatus.rank = value; } }


    [SerializeField] private GameObject player;
    public GameObject _Player {protected get { return player;} set { player = value; } }

    public abstract void CalcStat(AttackStatus status, AttackCardInfo info);

    public virtual Quaternion ChaseTarget(GameObject player, GameObject target) 
    {
        return Quaternion.LookRotation(player.transform.position - target.transform.position);
    }
    public abstract void Skill_1();

    public abstract void Skill_2();
    public abstract void Skill_3();

    protected abstract void ExcuteAttack();

    protected virtual void OnHited()
    {
        _Player.GetComponent<PlayerData>();
    }

    //public abstract ITimeEvent TimeEvent();

    public abstract void TimeEvent(float time);
}
