

public class GuidedAttack : AbstractAttack
{

    AttackType attackType = AttackType.guided;
    public override AttackType GetAttackType()
    {
        return attackType;
    }

}
