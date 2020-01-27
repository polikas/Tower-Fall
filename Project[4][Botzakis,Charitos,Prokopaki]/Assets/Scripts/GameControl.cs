using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private bool isPaused;
    private bool isDone;
    private JengaClick clickControl;
    private int currentTurnIndex;
    private int currentPlayerIndex;
    public CollisionControl collisionControl;
    void Start()
    {
        
        clickControl = this.GetComponent<JengaClick>();
        currentTurnIndex = clickControl.getTurnIndex();
        updatePlayerTurn(currentTurnIndex);
    }
    private void updatePlayerTurn(int turnIndex)
    {
        if (clickControl.getTurnStatus() || currentTurnIndex == 0)
        {
            if (turnIndex % 2 == 0)
            {
                currentPlayerIndex = 1;
                print("player 1 turn"); //ui here
                UiManager.Instance.setPlayerTurn(currentPlayerIndex);
            }
            else if (turnIndex % 2 == 1)
            {
                currentPlayerIndex = 2;
                print("player 2 turn"); //ui here
                UiManager.Instance.setPlayerTurn(currentPlayerIndex);
            }
            currentTurnIndex = clickControl.getTurnIndex();
        }
    }

    void Update()
    {
        if (!collisionControl.checkGameOver())
        {
            checkPause();
            if (clickControl.getTurnIndex() > currentTurnIndex)
            {
                updatePlayerTurn(clickControl.getTurnIndex());
            }
        }
        else
        {
            print("epeseeee");
            UiManager.Instance.setGameOverPanel(true);
            if(currentPlayerIndex == 1)
            UiManager.Instance.setGameOverText(2);
            else if (currentPlayerIndex == 2)
                UiManager.Instance.setGameOverText(1);
        }
        
    }
    #region PAUSE CONTROL
    private void pauseGame()
    {
        isPaused = true;
        print("paused");
        Time.timeScale = 0; //set timescale to 0
        UiManager.Instance.setPausePanel(isPaused);
    }
    public void resumeGame()
    {
        isPaused = false;
        print("resumed");
        Time.timeScale = 1; //set timescale to 1
        UiManager.Instance.setPausePanel(isPaused);
    }

    private void checkPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();
        }

    }
    #endregion



}
