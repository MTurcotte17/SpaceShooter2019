using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data/EnnemiData", fileName="new Ennemi")]
public class EnnemiData : ScriptableObject
{
    [Header("Shooting")]
    [SerializeField]
    private float m_Delay;
    [SerializeField]
    private float m_FireRate;

    [Header("Movement")]
    [SerializeField]
    private float m_Speed;

    [Header("Evasive")]
    [SerializeField]
    private Done_Boundary m_Boundary;
    [SerializeField]
	private float m_Tilt;
    [SerializeField]
	private float m_Dodge;
    [SerializeField]
	private float m_Smoothing;
    [SerializeField]
	private Vector2 m_StartWait;
    [SerializeField]
	private Vector2 m_ManeuverTime;
    [SerializeField]
	private Vector2 m_ManeuverWait;

    [Header("Spec(s)")]
    [SerializeField]
    private int m_Score;

    [Header("Dead")]
    [SerializeField]
    private GameObject m_Explosion;

    public float GetFireRate()
    {
        return m_FireRate;
    }

    public float GetDelay()
    {
        return m_Delay;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    public Done_Boundary GetBoundary()
    {
        return m_Boundary;
    }

    public float GetTilt()
    {
        return m_Tilt;
    }

    public float GetDodge()
    {
        return m_Dodge;
    }

    public float GetSmoothing()
    {
        return m_Smoothing;
    }

    public Vector2 GetStartWait()
    {
        return m_StartWait;
    }

    public Vector2 GetManeuverTime()
    {
        return m_ManeuverTime;
    }

    public Vector2 GetManeuverWait()
    {
        return m_ManeuverWait;
    }

    public int GetScore()
    {
        return m_Score;
    }

    public GameObject GetExplosionEffect()
    {
        return m_Explosion;
    }
}
