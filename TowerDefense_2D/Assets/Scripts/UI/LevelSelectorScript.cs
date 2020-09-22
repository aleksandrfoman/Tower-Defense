using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelectorScript
{

    public GameObject levelSlectorGameObject;

    public void Init()
    {
        levelSlectorGameObject = GameObject.Find("LevelMenu");
        Hide();
    }
    public void Show()
    {
        levelSlectorGameObject.SetActive(true);
    }
    public void Hide()
    {
        levelSlectorGameObject.SetActive(false);
    }


}
