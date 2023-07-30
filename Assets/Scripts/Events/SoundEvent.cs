using UnityEngine;

public class SoundEvent : SelectEvent
{
    public SoundEvent() : base()
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new SoundEvent(); } }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += SoundFunc_1;
            OnExecute += SoundFunc_2;
        }
    }

    private void SoundFunc_1(SelectEvent @event)
    {
        Debug.Log("SoundFunc_1");
        //Time.timeScale = 0.5f;
    }
    private void SoundFunc_2(SelectEvent @event)
    {
        Debug.Log("SoundFunc_2");
    }

}
