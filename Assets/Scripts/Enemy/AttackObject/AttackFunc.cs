using UnityEngine;

public abstract class AttackFunc : MonoBehaviour, IUseSkill
{
    public AttackType attackType;
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

}
