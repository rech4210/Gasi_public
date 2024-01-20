public class BulletAttack : AbstractAttack
{
    public void Start()
    {
        FindBuffWithAttackGenerator();
    }
    // 온체크시 버프 매니저에게 영향을 줘야함.수정? 어택 제너레이터에서 해야할듯.
    public override void OnChecked()
    {
        if ((int)attackCardInfo.attackCardEnum > skillCheckNum)
        {
            Skill<BulletTurret>();
        }
        else if (attackCardInfo.attackCardEnum == AttackCardEnum.generate)
        {
            attackGenerator?.Generate<BulletTurret>(attackStatus,attackCardInfo);
        }
        // 조건 바꿔야할듯? 수정
        else if ((int)attackCardInfo.attackCardEnum < skillCheckNum)
        {
            attackGenerator.IncreaseTargetStat<BulletTurret>(attackStatus, attackCardInfo);
        }
        attackGenerator.AddorUpdateAttackDictionary(attackCode);

        this.gameObject.SetActive(false);
    }

    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
}
