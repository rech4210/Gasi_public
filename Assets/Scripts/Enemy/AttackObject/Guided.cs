using UnityEngine;

public class Guided : AttackFunc, IUseSkill
{
    private void Update()
    {
        ExcuteAttack();
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    //var rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
    //    //Gizmos.matrix = rotationMatrix;
    //    Gizmos.DrawRay(this.transform.position, transform.position - _Player.transform.position);

    //}
    private void FixedUpdate()
    {
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
    protected override void ExcuteAttack()
    {
    }
}
