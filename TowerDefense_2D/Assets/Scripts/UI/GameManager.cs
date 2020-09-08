using UnityEngine;
public class GameManager : MonoBehaviour
{
    private bool gameIsOver; //Конец игры
    public GameObject gameOverUI; //Канвас поражения
    public GameObject completeLevelUI; //Канвас победы

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
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}