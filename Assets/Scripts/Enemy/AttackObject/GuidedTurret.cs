using System.Collections;
using UnityEngine;

public class GuidedTurret : AttackFunc, IUseSkill
{

    private void FixedUpdate()
    {
        transform.rotation = new Quaternion
            (transform.rotation.x, ChaseTarget(_Player, this.gameObject).y
            , transform.rotation.z, ChaseTarget(_Player, this.gameObject).w);
    }
    public override void CalcStat(AttackStatus status, AttackCardInfo info)
    {
        switch (info.attackCardEnum)
        {
            case AttackCardEnum.duration: _Duration *= status.duration; 
                break;
            case AttackCardEnum.scale:   _Scale *= status.scale;
                break;
            case AttackCardEnum.point:  _Point *= status.point;
                break;
            case AttackCardEnum.speed:  _Speed *= status.speed;
                break;
                 default:  break;
        }
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
    void Start()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        while (true)
        {
            ExcuteAttack();
            yield return new WaitForSeconds(_AttackStatus.duration);
        }

    }
    protected override void ExcuteAttack()
    {
        //var atkobj = Instantiate(attackObject, transform.position + transform.forward, transform.rotation,transform);
        //atkobj.GetComponent<AtkObjStat>().GetAtkObjPoint(_AttackStatus);
    }
}
