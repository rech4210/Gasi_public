using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEvent : Events<SoundEvent>
{
    public override void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActionInitiallize()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += SoundFunc_1;
            OnExecute += SoundFunc_2;
        }
    }

    private void SoundFunc_1()
    {
        Debug.Log("SoundFunc_1");
        //Time.timeScale = 0.5f;
    }
    private void SoundFunc_2()
    {
        Debug.Log("SoundFunc_2");
    }

}
