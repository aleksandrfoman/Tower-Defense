using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver;

    public GameObject gameOverUI;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
            return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Win");
        PlayerPrefs.SetInt("levelReached",levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }
}