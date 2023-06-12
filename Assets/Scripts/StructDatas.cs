
#region 버프 종류, 버프 데이터

public struct BuffData
{
    char buffCode;
    public BuffStat stat;

    public BuffData(char buffCode, BuffStat stat)
    {
        this.buffCode = buffCode;
        this.stat = stat;
    }
}
//public enum BuffCode
//{
//    Health,
//    Speed,
//    Wisdom,
//    Agility,
//    Endurance,
//    Power,
//    Remove,
//}

public struct BuffStat
{
    public string buffEnumName;
    public int rank;
    public int point;
    public int useValue;
    public int upValue;

    public BuffStat(string buffEnumName, int rank, int point, int useValue, int upValue)
    {
        this.buffEnumName = buffEnumName;
        this.rank = rank;
        this.point = point;
        this.useValue = useValue;
        this.upValue = upValue;
    }
} 
#endregion

#region 공격 종류, 공격 데이터
public enum AttackType
{
    laser,
    guided,
    bullet,
    trap
}

public struct AttackStatus
{
    public int rank;
    public int point;
    public float duration;
    public float scale;

    public AttackStatus(int rank, int point, float duration, float scale)
    {
        this.rank = rank;
        this.point = point;
        this.duration = duration;
        this.scale = scale;
    }
} 
#endregion