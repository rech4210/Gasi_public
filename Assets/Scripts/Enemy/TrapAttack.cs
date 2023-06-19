
public class TrapAttack : AbstractAttack
{

    AttackType attackType = AttackType.trap;
    public override AttackType GetAttackType()
    {
        return attackType;
    }
}
