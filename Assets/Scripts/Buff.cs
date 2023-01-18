using UnityEditor.Rendering;
using UnityEngine;

public abstract class Buff : StatusEffect
{
    public int point;
    public abstract void BuffUse();
    public abstract void BuffUp();
    public abstract void BuffDown();
    public abstract void RankUp(int rank);
}
