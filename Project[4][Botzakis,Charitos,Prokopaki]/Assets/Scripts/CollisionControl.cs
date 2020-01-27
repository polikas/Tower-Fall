using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    private bool gameOver;
    void Start()
    {
        gameOver = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "marble" || other.tag == "wood" && !gameOver)
        {
            gameOver = true;
          
        }
    }
    public bool checkGameOver()
    {
        return gameOver;
    }
}
