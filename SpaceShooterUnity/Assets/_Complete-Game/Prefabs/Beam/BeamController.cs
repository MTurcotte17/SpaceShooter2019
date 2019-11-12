using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    private bool m_StartLeft = true;
    private float m_WaitTimer = 2;
    private float m_WaitCountdown = 0;
    private float m_TravelTime = 3f;
    private bool m_AreSettingsSet = false;
    private Quaternion m_CurrentRotation = Quaternion.identity;
    private Quaternion m_EndRotation = Quaternion.identity;
    private Quaternion m_LerpRotation = Quaternion.identity;
    private float m_rotvalue= 0f;
    private float m_testtimer = 0f;

    private Done_GameController m_GameController;

    [SerializeField]
    private GameObject m_PlayerExplosion;


/*
    public void SetSettings(bool aStartLeft, float aWaitTime, float aTravelTime)
    {
        m_StartLeft = aStartLeft;
        m_WaitTimer = aWaitTime;
        m_TravelTime = aTravelTime;
        m_AreSettingsSet = true;
        if(m_StartLeft)
        {
            m_CurrentRotation.y = 28.5f;
            m_EndRotation.y = -28.5f;

        }
        else if(!m_StartLeft)
        {
            m_CurrentRotation.y = -28.5f;
            m_EndRotation.y = 28.5f;
        }
        //m_LerpRotation = m_CurrentRotation;
        //transform.Rotate(m_CurrentRotation.eulerAngles);
        //transform.Rotate(new Vector3(0, m_CurrentRotation.y, 0));
        Debug.Log(m_CurrentRotation.x + "  " + m_CurrentRotation.y + "  " + m_CurrentRotation.z);
        transform.Rotate(m_CurrentRotation.eulerAngles);
        Debug.Log(transform.rotation.y);
    }
*/

    public void SetController(Done_GameController aController)
    {
        m_GameController = aController;
    }

    private void Update()
    {
     /*  

        //Debug.Log(m_testtimer);
        if(m_AreSettingsSet)
        {
            if(m_WaitCountdown >= m_WaitTimer)
            {
                /* //m_floatspeed = 
                m_LerpRotation = Quaternion.Slerp(m_CurrentRotation, m_EndRotation, m_testtimer);
                Debug.Log(m_LerpRotation);
                transform.Rotate(m_LerpRotation.eulerAngles);*/

                /*
                m_rotvalue = Mathf.Lerp(m_CurrentRotation.y, m_EndRotation.y, m_testtimer);
                m_LerpRotation.y = m_rotvalue;
                Debug.Log(m_LerpRotation.y);
                transform.rotation = m_LerpRotation;
                m_testtimer += Time.fixedDeltaTime * (m_TravelTime * 0.1f);
               // Debug.Log(m_testtimer);
                transform.rotation = Quaternion.Slerp(transform.rotation, m_EndRotation, m_testtimer);

                
                
            }
            else
            {
                m_WaitCountdown += Time.deltaTime;
            }
        }
        */
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if(aCol.tag == "Player")
        {
            Instantiate(m_PlayerExplosion, aCol.transform.position, Quaternion.identity);
            Destroy(aCol.gameObject);
            m_GameController.GameOver();
        }
    }


    public void Death()
    {
        Destroy(gameObject);
    }
    
}
