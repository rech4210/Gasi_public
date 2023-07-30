using UnityEngine;

public class TransitionEvent : SelectEvent
{

    public TransitionEvent() : base()
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new TransitionEvent(); } }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Trans_1;
            OnExecute += Trans_2;
        }
    }

    // there is ExecuteEvent in Base

    private void Trans_1(SelectEvent @event)
    {
        Debug.Log("Trans_1");
    }
    private void Trans_2(SelectEvent @event)
    {
        Debug.Log("Trans_2");
    }
}
