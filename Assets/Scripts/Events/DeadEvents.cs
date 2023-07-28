using UnityEngine;

public class DeadEvents : Events<DeadEvents>
{
    public DeadEvents() : base() { }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Dead_1;
            OnExecute += Dead_2;
        }
    }

    // there is ExecuteEvent in Base

    private void Dead_1(DeadEvents @event )
    {
        Debug.Log("Dead_1");
        TimeEvent.instance.ExecuteEvent();
    }
    private void Dead_2(DeadEvents @event)
    {
        Debug.Log("Dead_2");
    }
}
