using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    private Text _waveTimerText;
    private Text _moneyText;
    private Text _livesText;
    private WaveSpawner _waveSpawner;

    private BuildManager _buildManager;

    public GameObject[] prefabTowerStandart;
    public GameObject[] prefabTowerUpgraded;

    [SerializeField]
    private List<TowerBlueprint> _towersList = new List<TowerBlueprint>();

    public GameObject shopButtonPref;

    private Transform _shopTransform;
    private Button _pauseButton;

    //UI Section
    private GameOverWinScript _gameOverWinScript;
    private PauseMenuScript _pauseMenuScript;

    private void Start()
    {

        _gameOverWinScript = new GameOverWinScript();
        _pauseMenuScript = new PauseMenuScript();

        Init();

        _gameOverWinScript.Init();
        _pauseMenuScript.Init();
    }

    private void Init()
    {
        _buildManager = BuildManager.instance;
        _pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        _pauseButton.onClick.AddListener(Pause);

        _waveSpawner = (WaveSpawner)FindObjectOfType(typeof(WaveSpawner));
        _waveTimerText = GameObject.Find("WaveTimerText").GetComponent<Text>();
        _moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        _livesText = GameObject.Find("LivesText").GetComponent<Text>();
        _shopTransform = GameObject.Find("UIShop").GetComponent<Transform>();

        CreateBluePrint();
        CreateButtonShop();
    }

    private void Pause()
    {
        _pauseMenuScript.Toggle();
    }
    private void Update()
    {
        _waveSpawner.countdown = Mathf.Clamp(_waveSpawner.countdown, 0f, Mathf.Infinity);
        _waveTimerText.text = string.Format("{0:00.00}", _waveSpawner.countdown);
        _moneyText.text = "$" + PlayerStats.Money.ToString();
        _livesText.text = "Lives: " + PlayerStats.Lives.ToString();

        if (PlayerStats.isGameOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            CheckGame(true);
        }
    }

    public void CreateBluePrint()
    {
        _towersList.Add(new TowerBlueprint(prefabTowerStandart[0], 100, prefabTowerUpgraded[0], 50, "Potion"));
        _towersList.Add(new TowerBlueprint(prefabTowerStandart[1], 110, prefabTowerUpgraded[1], 60, "Boom"));
        _towersList.Add(new TowerBlueprint(prefabTowerStandart[2], 120, prefabTowerUpgraded[2], 70, "Rare"));
        _towersList.Add(new TowerBlueprint(prefabTowerStandart[3], 130, prefabTowerUpgraded[3], 80, "Laser"));
    }

    public void CreateButtonShop()
    {
        GameObject shopItemButton;

        for (int i = 0; i < _towersList.Count; i++)
        {
            shopItemButton = Instantiate(shopButtonPref);

            shopItemButton.transform.Find("ShopTowerItemText").GetComponent<Text>().text = _towersList[i].nameTower;
            shopItemButton.transform.Find("costBG").transform.Find("CostText").GetComponent<Text>().text = "$ " + _towersList[i].cost.ToString();

            var selectTowerIndex = i;
            shopItemButton.GetComponent<Button>().onClick.AddListener(delegate{SelectTower(selectTowerIndex);});
            shopItemButton.transform.SetParent(_shopTransform);
        }
    }
    public void SelectTower(int value)
    {
        _buildManager.SelectTowerToBuild(_towersList[value]);
    }

    public void CheckGame(bool value)
    {
        _gameOverWinScript.EndGame(value);
    }
}
