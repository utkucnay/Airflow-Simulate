using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(this);

            Debug.LogWarning("2 Instance Created");
        }
    }

    public static T instance;
}
