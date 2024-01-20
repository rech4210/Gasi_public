using System.Collections;
using UnityEngine;

public class BulletObj : AtkObjStat<BulletObj>,IUseSkill
{

    public override void Initialize(AttackStatus attackStatus, bool skill_1, bool skill_2)
    {
        GetAtkObjPoint(attackStatus);
        if (skill_1)
        {
            Skill();
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward* Time.deltaTime * speed);
    }

    public void Skill()
    {
        throw new System.NotImplementedException();
    }
}