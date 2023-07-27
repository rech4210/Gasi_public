using Unity.VisualScripting;
using UnityEngine;


public abstract  class Events<T> :MonoBehaviour where T : Events<T>
{
    public  static T instance;
    public Events()
    {
        instance = (T)this;
    }

    public static System.Action<T> OnExecute;

    protected abstract void Execute();
    // make some method in here and Event Works
    public virtual void ExecuteEvent()
    {
        Execute(); // maybe Change?
        OnExecute?.Invoke((T)this);
    }
}


