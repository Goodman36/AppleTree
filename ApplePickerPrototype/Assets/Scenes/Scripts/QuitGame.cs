using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
