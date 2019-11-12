using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private enum BossState
    {
        Bolt,
        Beam,
        Bombs
    }

    [SerializeField]
    private int m_Health = 25;



    [SerializeField]
    private GameObject m_BoltPrefab;
   // [SerializeField]
   // private GameObject m_BombPrefab;
    [SerializeField]
    private GameObject m_BeamPrefab;
    [SerializeField]
    private GameObject m_BeamStartPos;
    

    [SerializeField]
    private int m_BoltToNextPhase = 25;
    private int m_BoltCount = 0;
    //[SerializeField]
   // private int m_BombsToNextPhase = 5;

    [SerializeField]
    private float m_BoltFireRate = 1f;
    private float m_BoltWait = 0f;
    [SerializeField]
    private float m_BoltSpeed = 5f;

    [SerializeField]
    private float m_BeamWaitTime = 1f;
    [SerializeField]
    private float m_BeamScrollTime = 3f;
    
   // [SerializeField]
   // private float m_BombSpeed = 3f;
    //[SerializeField]
   // private float m_MinBombTimer = 1f;
   // public float m_MaxBombTimer = 3f;

    [SerializeField]
    private BossState m_CurrentState = BossState.Bolt;
    [SerializeField]
    private GameObject m_Bolt1StartPos;
    [SerializeField]
    private GameObject m_Bolt2StartPos;

    [SerializeField]
    private float m_MaxCannon1Angle = -140f;
    [SerializeField]
    private float m_MinCannon1Angle = -200f;
    [SerializeField]
    private float m_MaxCannon2Angle = -160f;
    [SerializeField]
    private float m_MinCannon2Angle = -220f;
    [SerializeField]
    private GameObject m_Explosion;

    private float m_NextPhaseTimer = 2f;
    private float m_NextPhaseCooldown = 0f;
    private bool m_SwitchingState = false;

    [SerializeField]
    private Done_GameController m_GameController;



    private void Update()
    {
        switch(m_CurrentState)
        {
            case BossState.Bolt:
            if(!m_SwitchingState)
            {
                BoltUpdate();
            }
            break;

            case BossState.Beam:
            if(!m_SwitchingState)
            {
                BeamUpdate();
            }
            break;

            case BossState.Bombs:
            if(!m_SwitchingState)
            {
                BombsUpdate();
            }
            break;
        }
        Debug.Log("Current State = "  + m_CurrentState);

        if(m_SwitchingState)
        {
            WaitForPhase();
        }
        
    }
    
    public void TakeController(Done_GameController aController)
    {
        m_GameController = aController;
    }

    private void SwitchState(BossState aState)
    {
        m_CurrentState = aState;
    }

    private void BoltUpdate()
    {
        if(m_BoltFireRate < m_BoltWait)
        {
            float Bolt1Angle = Random.Range(m_MinCannon1Angle, m_MaxCannon1Angle);
            float Bolt2Angle = Random.Range(m_MinCannon2Angle, m_MaxCannon2Angle);
            //Debug.Log("Rot1 = " + Bolt1Angle + "   Rot2 = "  + Bolt2Angle);
            Quaternion Rot1 = Quaternion.identity;
            Quaternion Rot2 = Quaternion.identity;
            Rot1.y = Bolt1Angle;
            Rot2.y = Bolt2Angle;
            //Debug.Log("Rot1 = " + Rot1.y + "   Rot2 = "  + Rot2.y);

            GameObject bolt1 = Instantiate(m_BoltPrefab, m_Bolt1StartPos.transform.position, Quaternion.identity);
            BoltController boltscript = bolt1.GetComponent<BoltController>();
            if(boltscript != null)
            {
                boltscript.InitValues(m_Bolt1StartPos.transform.position, m_BoltSpeed, Rot1);
            }

            GameObject bolt2 = Instantiate(m_BoltPrefab, m_Bolt2StartPos.transform.position, Quaternion.identity);
            BoltController bolt2script = bolt2.GetComponent<BoltController>();
            if(bolt2script != null)
            {
                bolt2script.InitValues(m_Bolt2StartPos.transform.position, m_BoltSpeed, Rot2);
            }


            

            m_BoltCount++;
            m_BoltWait = 0f;
            if(m_BoltCount >= m_BoltToNextPhase)
            {
                SwitchState(BossState.Beam);
                m_SwitchingState = true;
                m_BoltCount = 0;
            }
        }
        else
        {
            m_BoltWait += Time.deltaTime;
        }
    }

    private void BeamUpdate()
    {
        GameObject Beam = Instantiate(m_BeamPrefab, m_BeamStartPos.transform.position, Quaternion.identity);
        BeamController BeamScript = Beam.GetComponent<BeamController>();
        if(BeamScript != null)
        {
            BeamScript.SetController(m_GameController);
        }
        m_SwitchingState = true;
        SwitchState(BossState.Bolt);
    }

    private void BombsUpdate()
    {

    }

    private void WaitForPhase()
    {
        if(m_NextPhaseTimer > m_NextPhaseCooldown)
        {
            m_SwitchingState = false;
            m_NextPhaseTimer = 0f;
        }
        else
        {
            m_NextPhaseTimer += Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider aCol)
    {
        //Debug.Log("in");
        if(aCol.tag != "Enemy" && aCol.tag != "Boundary")
        {
            Instantiate(m_Explosion, aCol.transform.position, Quaternion.identity);
            Destroy(aCol.gameObject);
            m_Health--;
        }
        if(m_Health <= 0)
        {
            Destroy(gameObject);
            
        }
    }

}
