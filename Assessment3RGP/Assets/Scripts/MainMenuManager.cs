using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
