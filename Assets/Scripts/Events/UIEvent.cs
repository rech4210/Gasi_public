
using UnityEngine;

public class UIEvent : Events<UIEvent>
{
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += UI_1;
            OnExecute += UI_2;
        }
    }

    private void UI_1()
    {
        Debug.Log("UI_1");
    }
    private void UI_2()
    {
        Debug.Log("UI_2");
    }
}
