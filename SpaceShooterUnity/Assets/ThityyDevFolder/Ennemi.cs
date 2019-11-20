using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    [Header("Shoot")]
	private float m_FireRate;
	private float m_Delay;

    [Header("Move")]
    private float m_Speed;

    [Header("Component(s)")]
    [SerializeField]
	private GameObject m_ShotPrefab;
	[SerializeField]
	private Transform m_ShotSpawn;
    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private Rigidbody m_Rb;

    [Header("Data")]
    [SerializeField]
    private EnnemiData m_Data;

    [Header("Evavise")]
    private Done_Boundary m_Boundary;
	private float m_Tilt;
	private float m_Dodge;
	private float m_Smoothing;
	private Vector2 m_StartWait;
	private Vector2 m_ManeuverTime;
	private Vector2 m_ManeuverWait;
	private float m_CurrentSpeed;
	private float m_TargetManeuver;
    private float m_NewManeuver;
    private Vector3 m_ManeuverVelo = new Vector3();
    private Vector3 m_ManeuverPos = new Vector3();

    [Header("Spec(s)")]
    private int m_Score;

    [Header("Dead")]
    private GameObject m_ExplosionPrefab;
	
    private void Awake()
    {
        GetData();
    }

    private void GetData()
    {
        m_FireRate = m_Data.GetFireRate();
        m_Delay = m_Data.GetDelay();

        m_Speed = m_Data.GetSpeed();

        m_Tilt = m_Data.GetTilt();
        m_Dodge = m_Data.GetDodge();
        m_Smoothing = m_Data.GetSmoothing();
        m_StartWait = m_Data.GetStartWait();
        m_ManeuverTime = m_Data.GetManeuverTime();
        m_ManeuverWait = m_Data.GetManeuverWait();

        m_Score = m_Data.GetScore();

        m_ExplosionPrefab = m_Data.GetExplosionEffect();
    }

	private void Start ()
	{
        Move();
        InitManoeuvre();
		InvokeRepeating ("Fire", m_Delay, m_FireRate);
        m_Boundary = m_Data.GetBoundary();
	}

    private void FixedUpdate ()
	{
		UpdateMaoeuvre();
	}

    private void OnTriggerEnter (Collider other)
	{
		if (m_ExplosionPrefab != null)
		{
			Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
		}

        if(other.GetComponent<Done_PlayerController>() != null)
        {
            Done_GameController.Instance.GameOver();
            
        }
		
		Done_GameController.Instance.AddScore(m_Score);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

    private void InitManoeuvre()
    {
        m_CurrentSpeed = m_Rb.velocity.z;
        StartCoroutine(Evade());
    }

    private void UpdateMaoeuvre()
    {
        m_NewManeuver = Mathf.MoveTowards (m_Rb.velocity.x, m_TargetManeuver, m_Smoothing * Time.deltaTime);

        m_ManeuverVelo.x = m_NewManeuver;
        m_ManeuverVelo.y = 0.0f;
        m_ManeuverVelo.z = m_CurrentSpeed;

        m_ManeuverPos.x = Mathf.Clamp(m_Rb.position.x, m_Boundary.xMin, m_Boundary.xMax);
        m_ManeuverPos.y = 0.0f;
        m_ManeuverPos.z = Mathf.Clamp(m_Rb.position.z, m_Boundary.zMin, m_Boundary.zMax);

		m_Rb.velocity = m_ManeuverVelo;
		m_Rb.position = m_ManeuverPos;
		
		m_Rb.rotation = Quaternion.Euler (0, 0, m_Rb.velocity.x * -m_Tilt);
    }

    private IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (m_StartWait.x, m_StartWait.y));
		while (true)
		{
			m_TargetManeuver = Random.Range (1, m_Dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (m_ManeuverTime.x, m_ManeuverTime.y));
			m_TargetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (m_ManeuverWait.x, m_ManeuverWait.y));
		}
	}

    private void Move()
    {
        m_Rb.velocity = -transform.forward * m_Speed;
    }

	private void Fire ()
	{
		Instantiate(m_ShotPrefab, m_ShotSpawn.position, m_ShotSpawn.rotation);
		m_AudioSource.Play();
	}
}
