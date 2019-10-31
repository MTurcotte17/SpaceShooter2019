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
        switch(choice)
        {
            case 0:
                Instantiate(m_Ship00, new Vector3(1, 0, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(m_Ship01, new Vector3(1, 0, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(m_Ship02, new Vector3(1, 0, 0), Quaternion.identity);
                break;
        }
    }
}
