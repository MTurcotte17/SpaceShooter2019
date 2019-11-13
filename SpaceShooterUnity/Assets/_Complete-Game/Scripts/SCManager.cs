using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCManager : MonoBehaviour
{
    private int m_PlayerNumber = 0;
    public int PlayerNumber
    {
        get { return m_PlayerNumber; }
        set { m_PlayerNumber = value; }
    }

    private static SCManager m_Instance;
    public static SCManager Instance         // public static AudioManager GetInstance()             PAREIL
    {                                           // {
        get { return m_Instance; }              //      return m_Insatnce;
    }

    protected void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(gameObject); /// si ya deja qulqun sur le trone je me detruit
        }
        else
        {
            m_Instance = this;  // this est le nouveau roi (SINGLETON)
        }

        DontDestroyOnLoad(gameObject);
    }
}
