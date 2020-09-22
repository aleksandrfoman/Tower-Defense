using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelectorScript
{
    private Transform _content;
    public GameObject levelSlectorGameObject;


    public GameObject levelButtonPrefab;
    public List<LevelBlueprint> levelsList = new List<LevelBlueprint>();


    public void Init()
    {
        _content = GameObject.Find("Content").GetComponent<Transform>();
        levelButtonPrefab = Resources.Load<GameObject>("Prefabs/UI/LevelButton");
        levelSlectorGameObject = GameObject.Find("LevelMenu");

        levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level01"));
        levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level02"));


        CreateButtonLevel();

        Hide();
    }

    public void CreateButtonLevel()
    {
        for (int i = 0; i < levelsList.Count; i++)
        {
            GameObject gObj = GameObject.Instantiate(levelButtonPrefab);

            gObj.transform.SetParent(_content);
            Text text = gObj.GetComponentInChildren<Text>();
            text.text = levelsList[i].indexName;

            var selectValueName = levelsList[i].indexName;
            gObj.GetComponent<Button>().onClick.AddListener(delegate { Select(selectValueName); });
        }
    }
    public void Select(string value)
    {
        SceneManager.LoadScene(value);
        Main.instance.ChangeState(GameState.Game);
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
