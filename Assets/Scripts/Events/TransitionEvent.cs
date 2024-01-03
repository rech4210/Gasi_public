using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionEvent : Events<TransitionEvent>
{
    public override void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActionInitiallize()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Trans_1;
            OnExecute += Trans_2;
        }
    }

    // there is ExecuteEvent in Base

    private void Trans_1()
    {
        Debug.Log("Trans_1");
    }
    private void Trans_2()
    {
        Debug.Log("Trans_2");
    }
}
