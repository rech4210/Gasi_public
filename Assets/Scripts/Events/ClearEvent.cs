using UnityEngine;

public class ClearEvent : Events<ClearEvent>
{
    public ClearEvent() : base() { }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Clear_1;
            OnExecute += Clear_1;
        }
    }
    // there is ExecuteEvent in Base
    private void Clear_1(ClearEvent @event)
    {
        Debug.Log("clear_1");
    }
    private void Clear_2(ClearEvent @event)
    {
        Debug.Log("clear_2");
    }
}
