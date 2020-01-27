using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    protected static UiManager instance;
    public Text turnText;
    public Text resultsText;
    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UiManager)FindObjectOfType(typeof(UiManager));
                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(UiManager) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
    private GameObject pausePanel;
    private GameObject gameOverPanel;
    private void Awake()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
    }
    void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        turnText.gameObject.SetActive(true);
       
    }
    public void setPausePanel(bool b)
    {
        pausePanel.SetActive(b);
    }
    public void setGameOverPanel(bool b)
    {
        gameOverPanel.SetActive(b);
    }
    public void setGameOverText(int winningIndex)
    {
       
            resultsText.text = "Player " + winningIndex.ToString() + " WINS!";
        turnText.gameObject.SetActive(false);
    }
    public void setPlayerTurn(int turnIndex)
    {
        if(turnIndex == 1)
        {
            turnText.color = Color.green;
        }
        else if(turnIndex == 2)
        {
            turnText.color = Color.red;
        }

        turnText.text = "Player " + turnIndex.ToString() + " turn";
    }
 
}
