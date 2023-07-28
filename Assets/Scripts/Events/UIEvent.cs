using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : Events<UIEvent>
{
    public UIEvent() : base() { }
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += UI_1;
            OnExecute += UI_2;
        }
    }

    private void UI_1(UIEvent events)
    {
        Debug.Log("UI_1");
    }
    private void UI_2(UIEvent @event)
    {
        Debug.Log("UI_2");
    }
}
