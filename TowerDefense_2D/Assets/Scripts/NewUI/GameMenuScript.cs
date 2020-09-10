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
    public GameObject _pauseMenu;
    public GameOverWinScript _gameOverMenu;
    public PauseMenuScript pms;
    private Button _pauseButton;

    public GameObject gameOverUI; //Канвас поражения
    public GameObject completeLevelUI; //Канвас победы


    private void Awake()
    {

        _pauseMenu = GameObject.Find("PauseMenu");
         pms = _pauseMenu.GetComponentInChildren<PauseMenuScript>();
         pms.gameObject.SetActive(false);
         _pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
         _gameOverMenu = GameObject.Find("GameOver/WinGame").GetComponentInChildren<GameOverWinScript>();
         _gameOverMenu.gameObject.SetActive(false);
    }

    private void Pause()
    {
        pms.Toggle();
    }



    private void Start()
    {
        _pauseButton.GetComponent<Image>().color = Color.yellow;
        _pauseButton.onClick.AddListener(Pause);

        _buildManager = BuildManager.instance;

        _waveSpawner = (WaveSpawner)FindObjectOfType(typeof(WaveSpawner));
        _waveTimerText = GameObject.Find("WaveTimerText").GetComponent<Text>();
        _moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        _livesText = GameObject.Find("LivesText").GetComponent<Text>();
        _shopTransform = GameObject.Find("UIShop").GetComponent<Transform>();

        CreateBluePrint();
        CreateButtonShop();
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
            EndGame(true);
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
        for (int i = 0; i < _towersList.Count; i++)
        {
            GameObject gObj = Instantiate(shopButtonPref);


            gObj.transform.SetParent(_shopTransform);
            Text[] shopTexts = gObj.GetComponentsInChildren<Text>();
            foreach (var text in shopTexts)
            {
                if (text.name == "ShopTowerItemText")
                {
                    text.text = _towersList[i].nameTower;
                }
                else if (text.name == "CostText")
                {
                    text.text ="$ "+ _towersList[i].cost.ToString();
                }
            }
            //Чтобы не было замыкания цыкла
            var selectTowerIndex = i;
            gObj.GetComponent<Button>().onClick.AddListener(delegate {SelectTower(selectTowerIndex);});
        }
    }
    public void SelectTower(int value)
    {

        _buildManager.SelectTowerToBuild(_towersList[value]);
    }

    void EndGame(bool gameWin)
    {
        PlayerStats.isGameOver = true;
        gameOverUI.SetActive(true);
    }
}
