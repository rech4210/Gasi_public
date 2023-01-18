public abstract class DeBuff : StatusEffect
{
    public int point;
    public abstract void DeBuffUse();
    public abstract void DeBuffUp();
    public abstract void DeBuffDown();
    public abstract void RankUp(int rank);
}
