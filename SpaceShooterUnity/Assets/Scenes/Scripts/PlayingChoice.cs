using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayingChoice : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ButtonChoice;

    [SerializeField]
    private GameObject m_Image;

    public void OpenChoice(int aChoice)
    {
        if(aChoice == 1)
        {
            m_Image.SetActive(false);
            m_ButtonChoice.SetActive(true);
        }
    }
}
