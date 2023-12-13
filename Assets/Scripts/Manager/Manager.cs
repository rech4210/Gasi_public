using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
{
    protected void Start()
    {
        if (instance != this && instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType(typeof(T)) as T;
            }
            return instance;
        }
    }
}
