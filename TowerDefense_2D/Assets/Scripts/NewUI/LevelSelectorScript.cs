using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorScript : MonoBehaviour
{
    public Button[] levelButtons;
    public string nameLevel;

    private void Start()
    {
        #region Prefs
        /* int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }*/
        #endregion

        levelButtons = GameObject.Find("LevelButton").GetComponents<Button>();
        levelButtons[0].onClick.AddListener(Select);
    }



    public void Select()
    {
     //nameLevel = levelButtons[0].name;


     SceneManager.LoadScene(nameLevel);
    }
}
