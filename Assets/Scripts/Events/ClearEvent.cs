using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearEvent : Events<ClearEvent>
{
    public override void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActionInitiallize()
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
