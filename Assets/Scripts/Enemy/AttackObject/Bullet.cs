using UnityEngine;

public class Bullet : AttackFunc
{
    AttackType type = AttackType.bullet;
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(_Player.transform.position);

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
