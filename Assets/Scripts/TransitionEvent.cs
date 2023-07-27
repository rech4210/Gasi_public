using UnityEngine;

public class TransitionEvent : Events<TransitionEvent>
{

    public TransitionEvent() : base() { }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Trans_1;
            OnExecute += Trans_2;
        }
    }

    // there is ExecuteEvent in Base

    private void Trans_1(TransitionEvent @event)
    {
        Debug.Log("Trans_1");
    }
    private void Trans_2(TransitionEvent @event)
    {
        Debug.Log("Trans_2");
    }
}
