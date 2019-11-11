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
    private GameObject m_ShipActivate;


    [SerializeField]
    private GameObject m_PlayerOneText;
    [SerializeField]
    private GameObject m_PlayerTwoText;

    [SerializeField]
    private bool m_isMulti;
    [SerializeField]
    private bool m_BossAchievement;

    [SerializeField]
    private Done_PlayerController m_PlayerController;
    private int countPlayer = 1;

    [SerializeField]
    private GameObject m_UIChoiceScreen;
    [SerializeField]
    private Done_GameController m_GameController;
    private int m_StartPos;

    private void Start()
    {
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

        }
    }
    public void ShipSpawn(int choice)
    {
        if (countPlayer == 1)
        {
            m_StartPos = -5;
        }
        else
        {
            m_StartPos = 5;
        }
        switch(choice)
        {
            case 0:
                Instantiate(m_Ship00, new Vector3(m_StartPos, 0, 0), Quaternion.identity);
                Done_PlayerController playerController = m_Ship00.GetComponent<Done_PlayerController>();
                if (countPlayer == 1)
                {
                    playerController.PlayerSwitch(ePlayerNumber.PlayerOne);
                }
                else
                {
                    playerController.PlayerSwitch(ePlayerNumber.PlayerTwo);
                }
                
                break;
            case 1:
                Instantiate(m_Ship01, new Vector3(m_StartPos, 0, 0), Quaternion.identity);
                Done_PlayerController playerController01 = m_Ship00.GetComponent<Done_PlayerController>();
                if (countPlayer == 1)
                {
                    playerController01.PlayerSwitch(ePlayerNumber.PlayerOne);
                }
                else
                {
                    playerController01.PlayerSwitch(ePlayerNumber.PlayerTwo);
                }
                break;
            case 2:
                Instantiate(m_Ship02, new Vector3(m_StartPos , 0, 0), Quaternion.identity);
                Done_PlayerController playerController02 = m_Ship00.GetComponent<Done_PlayerController>();
                if (countPlayer == 1)
                {
                    playerController02.PlayerSwitch(ePlayerNumber.PlayerOne);
                }
                else
                {
                    playerController02.PlayerSwitch(ePlayerNumber.PlayerTwo);
                }
                break;
        }


        if (PlayerPrefs.GetInt("PlayerNumber") == 1 && countPlayer == 1)
        {
            m_UIChoiceScreen.SetActive(false);
            m_GameController.GameStart = true;
        }
        else if (PlayerPrefs.GetInt("PlayerNumber") == 2 && countPlayer == 2)
        {
            m_UIChoiceScreen.SetActive(false);
            m_GameController.GameStart = true;
        }

        countPlayer++;
    }
}
