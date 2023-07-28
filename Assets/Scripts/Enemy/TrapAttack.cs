
using Unity.VisualScripting;

public class TrapAttack : AbstractAttack
{
    public void Start()
    {
        FindBuffWithAttackGenerator();
    }
    // 온체크시 버프 매니저에게 영향을 줘야함.수정? 어택 제너레이터에서 해야할듯.
    public override void OnChecked()
    {
        if ((int)_AttackCardInfo.attackCardEnum > skillCheckNum)
        {
            Skill();
        }
        else if (_AttackCardInfo.attackCardEnum == AttackCardEnum.generate)
        {
            attackGenerator?.Generate(_AttackStatus);
        }
        // 조건 바꿔야할듯? 수정
        else if ((int)_AttackCardInfo.attackCardEnum < skillCheckNum)
        {
            attackGenerator.IncreaseTargetStat(_AttackStatus, _AttackCardInfo);
        }
        buffManager.AddorUpdateAttackDictionary(attackCode,_AttackStatus);

        this.gameObject.SetActive(false);
    }

    public override void SetCardInfo()
    {
        base.SetCardInfo();
    }
}
