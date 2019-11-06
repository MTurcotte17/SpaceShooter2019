﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;
    public static T Instance
    {
        get
        {
            return m_Instance;
        }
    }

    protected virtual void Awake()
    {
        if(m_Instance != null)
        {
            Destroy(gameObject);
        }
        
        m_Instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
