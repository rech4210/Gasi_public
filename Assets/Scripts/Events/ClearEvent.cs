using Unity.VisualScripting;
using UnityEngine;

public class ClearEvent : Events<ClearEvent>
{
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Clear_1;
            OnExecute += Clear_2;
        }
    }

    private void Clear_1()
    {
        Debug.Log("clear_1");
    }
    private void Clear_2()
    {
        Debug.Log("clear_2");
    }

}
