using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	[SerializeField]
	private GameObject shot;
	[SerializeField]
	private Transform shotSpawn;
	[SerializeField]
	private float fireRate;
	[SerializeField]
	private float delay;
	

	private void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	private void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}
}
