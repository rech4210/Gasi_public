
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvent : Events<UIEvent>
{
    public override void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActionInitiallize()
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
