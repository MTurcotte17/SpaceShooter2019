using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public enum ePlayerNumber
	{
		PlayerOne,
		PlayerTwo
	}
	private ePlayerNumber m_PlayerNumber;
	
	[SerializeField]
	private float m_speed;
	[SerializeField]
	private float m_tilt;
	public Done_Boundary m_boundary;

	[SerializeField]
	private GameObject m_shot;
	[SerializeField]
	private Transform m_shotSpawn;
	[SerializeField]
	private float m_fireRate;
	 
	private float m_nextFire;
	
	void Update ()
	{
		// add a swtich case as well for firing
		
		switch (m_PlayerNumber)
		{
			case ePlayerNumber.PlayerOne:
				if (Input.GetButton("Fire1") && Time.time > m_nextFire) 
				{
					m_nextFire = Time.time + m_fireRate;
					Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation);
					GetComponent<AudioSource>().Play ();
				}
			break;

			case ePlayerNumber.PlayerTwo:
				if (Input.GetButton("Fire2") && Time.time > m_nextFire) 
				{
					m_nextFire = Time.time + m_fireRate;
					Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation);
					GetComponent<AudioSource>().Play ();
				}
			break;
		}
	}

	void FixedUpdate ()
	{
		//switch case if 1 or 2 player mode
		switch (m_PlayerNumber)
		{
			case ePlayerNumber.PlayerOne:
				float moveHorizontal = Input.GetAxis ("Horizontal1");
				float moveVertical = Input.GetAxis ("Vertical1");

				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				GetComponent<Rigidbody>().velocity = movement * m_speed;
			break;

			case ePlayerNumber.PlayerTwo:
				float moveHorizontal2 = Input.GetAxis("Horizontal2");
				float moveVertical2 = Input.GetAxis("Vertical2");

				Vector3 movement2 = new Vector3 (moveHorizontal2, 0.0f, moveVertical2);
				GetComponent<Rigidbody>().velocity = movement2 * m_speed;
			break;
		}
		
		/// do not add in the switch case
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, m_boundary.xMin, m_boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, m_boundary.zMin, m_boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -m_tilt);
	
		
		
	}
}
