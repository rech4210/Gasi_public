using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : SelectEvent
{
    public UIEvent() : base()
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new UIEvent(); } }
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += UI_1;
            OnExecute += UI_2;
        }
    }

    private void UI_1(SelectEvent events)
    {
        Debug.Log("UI_1");
    }
    private void UI_2(SelectEvent @event)
    {
        Debug.Log("UI_2");
    }
}
