using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChoice : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Ship00;
    [SerializeField]
    private GameObject m_Ship01;
    [SerializeField]
    private GameObject m_Ship02;
    [SerializeField]
    private Transform m_SpawnPos;

    [SerializeField]
    private GameObject m_ShipActivate;


    [SerializeField]
    private GameObject m_PlayerOneText;
    [SerializeField]
    private GameObject m_PlayerTwoText;

    [SerializeField]
    private bool m_isMulti;
    private int m_PlayerNumber = 0;
    [SerializeField]
    private bool m_BossAchievement;

    [SerializeField]
    private Done_GameController m_GameController;

    [SerializeField]
    private GameObject m_CanvasActivation;
    private int choiceCount = 0;
    private float t = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("NumberPlayer") == 2 )
        {
            m_isMulti = true;
        }

        if (m_BossAchievement)
        {
            m_ShipActivate.SetActive(true);
        }
        else
        {
            m_ShipActivate.SetActive(false);
        }

        if (m_isMulti)
        {
            m_PlayerNumber++;
        }
    }

    public void ShipSpawn(int choice)
    {
      
        if (choice == 0 )
        {
            Instantiate(m_Ship00, new Vector3(t, 0, 0), Quaternion.identity);
        }
        else if (choice == 1)
        {
            Instantiate(m_Ship01, new Vector3(t, 0, 0), Quaternion.identity);
        }
        else if (choice == 2)
        {
            Instantiate(m_Ship02, new Vector3(t, 0, 0), Quaternion.identity);
        }
        
        t += 5f;

        if (choiceCount > 0)
        {
            m_PlayerOneText.SetActive(false);
            m_PlayerTwoText.SetActive(true);
            m_GameController.ShipSpawnedhoice(true);
        }

        choiceCount++;
    }
}
