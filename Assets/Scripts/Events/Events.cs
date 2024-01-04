using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Events<T> :MonoBehaviour, ISceneLoaded where T : Events<T>
{
    protected void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(this.gameObject);
        }
        ActionInitiallize();
    }

    private static  T instance;
    public static T Instance {
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
            }
            return instance;
        } 
    }
    protected System.Action OnExecute;

    protected abstract void ActionInitiallize();
    public virtual void ExecuteEvent()
    {
        OnExecute?.Invoke();
    }

    public abstract void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1);
    // Manager에서는 이를 구현하지 않는데, Event와 Manager 의 역할을 나눌게 아니면 하나로 통합하는게 맞다.
}


