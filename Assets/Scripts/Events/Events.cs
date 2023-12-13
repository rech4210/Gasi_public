using Unity.VisualScripting;
using UnityEngine;

public abstract class Events<T> :MonoBehaviour where T : Events<T>
{
    protected void Start()
    {
        Debug.Log((T)this);
        Execute(); // maybe Change?
        if(instance != this && instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
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

    protected abstract void Execute();
    public virtual void ExecuteEvent()
    {
        OnExecute?.Invoke();
    }

}


