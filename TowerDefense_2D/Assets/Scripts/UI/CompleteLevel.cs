using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public string nextLevel = "Level02"; //Имя некст сцены
    public int levelToUnlock = 2; //Лвл который анлокнится

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("GoToMenu");
    }


}
