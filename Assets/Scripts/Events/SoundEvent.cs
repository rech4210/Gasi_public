using UnityEngine;

public class SoundEvent : Events<SoundEvent>
{
    public SoundEvent() : base() { }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += SoundFunc_1;
            OnExecute += SoundFunc_2;
        }
    }

    private void SoundFunc_1(SoundEvent @event)
    {
        Debug.Log("SoundFunc_1");
        //Time.timeScale = 0.5f;
    }
    private void SoundFunc_2(SoundEvent @event)
    {
        Debug.Log("SoundFunc_2");
    }

}
