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

    private GameObject m_ShipChoice;

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

<<<<<<< HEAD
=======
    [SerializeField]
    private Done_PlayerController m_PlayerController;
>>>>>>> e47737f5c4babb65d1e3fc291a112ef130a07b93
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
<<<<<<< HEAD
        Debug.Log(countPlayer);

=======
>>>>>>> e47737f5c4babb65d1e3fc291a112ef130a07b93
        if (countPlayer == 1)
        {
            m_StartPos = -5;
        }
        else
        {
            m_StartPos = 5;
        }
<<<<<<< HEAD

=======
>>>>>>> e47737f5c4babb65d1e3fc291a112ef130a07b93
        switch(choice)
        {
            
            case 0:
<<<<<<< HEAD
                m_ShipChoice = m_Ship00;
            
                //Done_PlayerController playerController = m_Ship00.GetComponent<Done_PlayerController>();
                //playerController.PlayerSwitch(ePlayerNumber.PlayerOne, 1);
                //if (countPlayer == 1)
                //{
                //    playerController.PlayerSwitch(ePlayerNumber.PlayerOne, 1);
                //}
                //else
                //{
                //    playerController.PlayerSwitch(ePlayerNumber.PlayerTwo, 2);
                //}

                break;
            case 1:
                m_ShipChoice = m_Ship01;
                //Done_PlayerController playerController = m_Ship01.GetComponent<Done_PlayerController>();
                //playerController.PlayerSwitch(ePlayerNumber.PlayerTwo, 2);
                //if (countPlayer == 1)
                //{
                //    playerController01.PlayerSwitch(ePlayerNumber.PlayerOne, 1);
                //}
                //else
                //{
                //    playerController01.PlayerSwitch(ePlayerNumber.PlayerTwo, 2);
                //}
                break;
            case 2:
                m_ShipChoice = m_Ship02;
                //m_ShipChoice = Instantiate(m_Ship02, new Vector3(m_StartPos , 0, 0), Quaternion.identity);
                //Done_PlayerController playerController02 = m_Ship02.GetComponent<Done_PlayerController>();
                //if (countPlayer == 1)
                //{
                //    playerController02.PlayerSwitch(ePlayerNumber.PlayerOne, 1);
                //}
                //else
                //{
                //    playerController02.PlayerSwitch(ePlayerNumber.PlayerTwo, 2);
                //}
                break;
        }

        Instantiate(m_ShipChoice, new Vector3(m_StartPos, 0, 0), Quaternion.identity);

        Done_PlayerController playerController = m_ShipChoice.GetComponent<Done_PlayerController>();

        if (countPlayer == 1)
        {
            GameObject PlayerOneShip = Instantiate(m_ShipChoice, new Vector3(m_StartPos, 0, 0), Quaternion.identity);
            Done_PlayerController PlayerOneController = PlayerOneShip.GetComponent<Done_PlayerController>();
            if(PlayerOneController != null)
            {
                PlayerOneController.PlayerSwitch(1);
            }
        }
        else
        {
            GameObject PlayerTwoShip = Instantiate(m_ShipChoice, new Vector3(m_StartPos, 0, 0), Quaternion.identity);
            Done_PlayerController PlayerTwoController = PlayerTwoShip.GetComponent<Done_PlayerController>();
            if(PlayerTwoController != null)
            {
                PlayerTwoController.PlayerSwitch(2);
            }
        }

=======
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

>>>>>>> e47737f5c4babb65d1e3fc291a112ef130a07b93

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
