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
            PlayerPrefs.SetInt("NumberPlayer", 1);
        }
        else if(aChoice == 2)
        {
            PlayerPrefs.SetInt("NumberPlayer", 2);
        }

        SceneManager.LoadScene("Done_Main");
    }
}
