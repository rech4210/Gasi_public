using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class LoadScene : Manager<LoadScene> // it will be need to change
{
    
    private float time;
    public Slider slider;
    private string sceneName = "MainScene";
    
    new async void Start()
    {
        //GetData();
        Console.WriteLine("done");
        await LoadAsyncScene();
    }


    //make await in here to control downloading asset
    // it seems need multiThread with unitask

    private async UniTask<GameObject> GetData()
    {
       var asset =  await Resources.LoadAsync<GameObject>(StringManager.Instance.buffData) as GameObject;
         await UniTask.WaitUntil(() => asset != null);
        return asset;
    }
    IEnumerator LoadAsyncScene()
    {
        //여기서 에러가 뜸.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            time += Time.time;
            slider.value = time / 10f;

            //fake loading
            if(time > 100)
            {
                //yield return new WaitForSeconds(1f);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;

        }

    }
    
}
