public class BulletAttack : AbstractAttack
{
    AttackType attackType = AttackType.bullet;
    public void Init()
    {
        base.SetAttackStatus(this._attackStatus);
    }
    public override AttackType GetAttackType()
    {
        return attackType;
    }

    public override void SetAttackStatus(AttackStatus attackStatus)
    {
        
    }
    
}
