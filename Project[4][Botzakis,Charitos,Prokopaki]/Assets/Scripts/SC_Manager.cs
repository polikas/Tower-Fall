using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Manager : MonoBehaviour
{
   public void GoToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void GoToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
