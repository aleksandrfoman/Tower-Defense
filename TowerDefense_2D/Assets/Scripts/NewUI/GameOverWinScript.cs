using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWinScript : MonoBehaviour
{
    public Button retryButton;
    public Button menuButton;
    public Text gameOverText;

    private void Start()
    {

    }

    public void EndGame(bool value)
    {
        PlayerStats.isGameOver = true;
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        if (value)
        {
            gameOverText.text = "Game over";
        }
        else
        {
            gameOverText.text = "WIN GAME HAHAHA";
        }
    }
}
