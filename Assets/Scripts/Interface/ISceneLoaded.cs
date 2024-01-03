using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneLoaded
{
    void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1);
}
