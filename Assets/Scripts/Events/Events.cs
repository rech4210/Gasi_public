using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Events<T> where T : Events<T>, new()
{
    public static T instance;
    //public static T Instance { get { return CheckInstance(); } set { instance = value; } }
    public Events()
    {
        if (instance != (T)this || instance == null)
        {
            instance = (T)this;
        }
    }

    //public abstract T ChangeInstance(SelectEvent @event);
    //{
    //    if (instance == null)
    //    {
    //        Debug.LogError("There is no instance");
    //        return null;
    //    }
    //    else
    //    {
    //        return instance;
    //    }
    //}

    public static System.Action<T> OnExecute;

    protected abstract void Execute();
    // make some method in here and Event Works
    public virtual void ExecuteEvent()
    {
        OnExecute = null;
        Execute(); // maybe Change?
        Debug.Log(instance);
        OnExecute?.Invoke((T)this);
    }
}


