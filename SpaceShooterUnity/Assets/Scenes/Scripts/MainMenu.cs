using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame(int aChoice)
    {
        SCManager.Instance.PlayerNumber = aChoice;   
        SceneManager.LoadScene("Done_Main");   
    }
}
