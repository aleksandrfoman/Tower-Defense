using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWinScript
{
    private Button _retryButton;
    private Button _menuButton;
    private Text _gameOverText;
    private Text _roundsText;
    private GameObject _gameOverUiGameObject;
    public void Init()
    {
        _gameOverUiGameObject = GameObject.Find("UIGameOver");
        _retryButton = GameObject.Find("Retry").GetComponent<Button>();
        _menuButton = GameObject.Find("Menu").GetComponent<Button>();
        _gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        _roundsText = GameObject.Find("Rounds").GetComponent<Text>();
        _retryButton.onClick.AddListener(RetryGameOver);
        _menuButton.onClick.AddListener(MenuGameOver);
        _gameOverUiGameObject.SetActive(false);
    }

    public void EndGame(bool value)
    {
        _gameOverUiGameObject.SetActive(true);
        _gameOverText.text = value ? "GAME OVER" : "WIN GAME";
        _roundsText.text = PlayerStats.Rounds.ToString();
        PlayerStats.isGameOver = true;
    }

    public void RetryGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
