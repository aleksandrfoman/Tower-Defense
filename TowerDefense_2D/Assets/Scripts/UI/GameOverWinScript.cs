using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWinScript : MonoBehaviour
{
    private Button _retryButton;
    private Button _menuButton;
    private Text _gameOverText;
    private Text _roundsText;

    private void Awake()
    {

        _retryButton = GameObject.Find("Retry").GetComponent<Button>();
        _menuButton = GameObject.Find("Menu").GetComponent<Button>();
        _gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        _roundsText = GameObject.Find("Rounds").GetComponent<Text>();

        _retryButton.onClick.AddListener(RetryGameOver);
        _menuButton.onClick.AddListener(MenuGameOver);
    }

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    public void EndGame(bool value)
    {
        gameObject.SetActive(true);
        if (value)
       {
           Debug.Log(value+"gover");
           PlayerStats.isGameOver = true;
           _gameOverText.text = "GAME OVER";
       }
        else
       {
           PlayerStats.isGameOver = true;
           _gameOverText.text = "WIN GAME";
       }
    }

    public void RetryGameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator AnimateText()
    {
        _roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            _roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
