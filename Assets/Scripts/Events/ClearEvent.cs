using Unity.VisualScripting;
using UnityEngine;

public class ClearEvent : SelectEvent
{
    public ClearEvent() : base() 
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new ClearEvent();  } }


    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Clear_1; 
            OnExecute += Clear_2;
        }
    }

    // there is ExecuteEvent in Base
    private void Clear_1(SelectEvent @event)
    {
        Debug.Log("clear_1");
    }
    private void Clear_2(SelectEvent @event)
    {
        Debug.Log("clear_2");
    }
}
