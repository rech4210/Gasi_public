using System.Collections;
using UnityEngine;

public class TrapTurret : AttackFunc<TrapTurret> , IUseSkill
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
            case AttackCardEnum.duration:
                _Duration *= status.duration;
                break;
            case AttackCardEnum.scale:
                _Scale *= status.scale;
                break;
            case AttackCardEnum.point:
                _Point *= status.point;
                break;
            case AttackCardEnum.speed:
                _Speed *= status.speed;
                break;
            default: break;
        }
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
        //Instantiate(attackObject,transform);
        var atkobj = Instantiate(attackObject);
        atkobj.GetComponent<AtkObjStat<TrapObj>>().Initialize(_AttackStatus,sk_1,sk_2,sk_3);
    }

    public override void TimeEvent(float time)
    {
        Debug.Log(time + this.gameObject.name);
    }

    public void Skill()
    {
        throw new System.NotImplementedException();
    }
}
