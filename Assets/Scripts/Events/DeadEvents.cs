using UnityEngine;

public class DeadEvents : SelectEvent
{
    public DeadEvents() : base()
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new DeadEvents(); } }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Dead_1;
            OnExecute += Dead_2;
        }
    }

    // there is ExecuteEvent in Base

    private void Dead_1(SelectEvent @event )
    {
        Debug.Log("Dead_1");
        TimeEvent.Instance.ExecuteEvent();
    }
    private void Dead_2(SelectEvent @event)
    {
        Debug.Log("Dead_2");
    }
}
