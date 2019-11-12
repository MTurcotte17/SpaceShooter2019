using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    private Vector3 m_InitPos = new Vector3();
    private float m_Speed = 0f;
    [SerializeField]
    private Rigidbody m_RB;
    [SerializeField]
    private GameObject m_PlayerExplosion;
    [SerializeField]
    private GameObject m_Explosion;
    private Quaternion m_Rotation = new Quaternion();

    public void InitValues(Vector3 aInitPos, float aSpeed, Quaternion aRotation)
    {
        m_InitPos = aInitPos;
        m_Speed = aSpeed;
        m_Rotation = aRotation;
        //Debug.Log(aRotation + "<- given rot || Set rot ->" + m_Rotation);
        transform.Rotate(new Vector3(0, m_Rotation.y, 0));
    }

    private void Update()
    {
        //transform.rotation = m_Rotation;
        //Debug.Log(m_Rotation);
        m_RB.velocity = transform.forward * m_Speed;
        //Debug.Log(transform.rotation.y);
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if(aCol.tag == "Boundary" || aCol.tag == "Enemy")
        {
            return;
        }

        if(m_Explosion != null)
        {
            Instantiate(m_Explosion, transform.position, transform.rotation);
        }

        if(aCol.tag == "Player")
        {
            Instantiate(m_PlayerExplosion, aCol.gameObject.transform.position, aCol.transform.rotation);
        }

        Destroy(aCol.gameObject);
        Destroy(gameObject);
    }


}
