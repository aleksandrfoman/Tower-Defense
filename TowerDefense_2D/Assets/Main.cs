using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    MainMenu,
    LevelSelect,
    Game
}
public class Main : MonoBehaviour
{
    private GameState currentState;

    private MainMenuScript _mainMenuScript;
    private LevelSelectorScript _levelSelectorScript;

    private Transform _content;

    public GameObject levelButtonPrefab;
    public List<LevelBlueprint> levelsList = new List<LevelBlueprint>();

    public static Main instance;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            Debug.Log("More one build manager");
        }
        instance = this;
    }

    public void CreateButtonLevel()
    {
        for (int i = 0; i < levelsList.Count; i++)
        {
            GameObject gObj = Instantiate(levelButtonPrefab);

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
        ChangeState(GameState.Game);
    }

    void Start()
    {
        _content = GameObject.Find("Content").GetComponent<Transform>();

        _mainMenuScript = new MainMenuScript();
        _levelSelectorScript = new LevelSelectorScript();

        _mainMenuScript.Init();
        _levelSelectorScript.Init();

        levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level01"));
        levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level02"));


        CreateButtonLevel();

        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                _mainMenuScript.Hide();
                //Вылючаем
                break;
            case GameState.Game:

                break;
            case GameState.LevelSelect:
                _levelSelectorScript.Hide();

                break;
        }
        currentState = newState;

        switch (currentState)
        {
            case GameState.MainMenu:
                _mainMenuScript.Show();
                //Включаем
                break;
            case GameState.Game:
                break;
            case GameState.LevelSelect:
                _levelSelectorScript.Show();
                break;
        }

    }
}
