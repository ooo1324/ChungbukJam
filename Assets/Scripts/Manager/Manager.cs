using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
{
    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
        init();
    }

    public abstract void init();

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
