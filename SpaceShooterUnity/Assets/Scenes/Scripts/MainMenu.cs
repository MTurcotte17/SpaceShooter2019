using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame(int aChoice)
    {

        if(aChoice == 1)
        {
            PlayerPrefs.SetInt("PlayerNumber", 1);
        }

        if(aChoice == 2)
        {
            PlayerPrefs.SetInt("PlayerNumber", 2);
        }
        SceneManager.LoadScene("MainGame");
    }
}
