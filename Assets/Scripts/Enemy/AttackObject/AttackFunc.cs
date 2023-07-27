using UnityEngine;

public abstract class AttackFunc : MonoBehaviour, IUseSkill
{
    AttackType attackType;

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //var rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        //Gizmos.matrix = rotationMatrix;
        Gizmos.DrawRay(this.transform.position, _Player.transform.position - transform.position);
    }

    public AttackType _AttackType { get { return attackType;} set {attackType = value;} }
    private GameObject player;
    public GameObject _Player {protected get { return player;} set { player = value; } }
    public abstract void Skill_1();

    public abstract void CalcStat(AttackStatus status, AttackCardInfo info);

    public virtual void ChaseTarget(GameObject player) 
    {
        Quaternion.LookRotation(player.transform.position);
    }

    public abstract void Skill_2();
    public abstract void Skill_3();

    protected abstract void ExcuteAttack();

    protected virtual void OnHited()
    {
        _Player.GetComponent<PlayerStat>();
    }

}
