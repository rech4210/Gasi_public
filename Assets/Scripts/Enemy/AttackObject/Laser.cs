using Unity.VisualScripting;
using UnityEngine;

public class Laser : AttackFunc, IUseSkill
{
    AttackType type = AttackType.laser;

    private void FixedUpdate()
    {
        if (_Player == null)
        {
            Debug.Log("null");
        }
        transform.rotation = Quaternion.LookRotation(_Player.transform.position - transform.position);
    }
    public override void CalcStat(AttackStatus status, AttackCardInfo info)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    public override void Skill_1()
    {
        throw new System.NotImplementedException();
    }
    public override void Skill_2()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_3()
    {
        throw new System.NotImplementedException();
    }
}
