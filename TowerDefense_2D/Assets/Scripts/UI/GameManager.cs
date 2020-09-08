using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; //Канвас поражения
    public GameObject completeLevelUI; //Канвас победы

    private void Update()
    {
        if (PlayerStats.isGameOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        PlayerStats.isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        PlayerStats.isGameOver = true;
        completeLevelUI.SetActive(true);
    }
}