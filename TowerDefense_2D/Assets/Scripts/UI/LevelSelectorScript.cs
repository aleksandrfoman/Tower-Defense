using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBlueprint
{
    public GameObject prefab;
    public string indexName;

    public LevelBlueprint(GameObject prefab, string indexName)
    {
        this.prefab = prefab;
        this.indexName = indexName;
    }
}

public class LevelSelectorScript : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    private List<LevelBlueprint> _levelsList = new List<LevelBlueprint>();
    private Transform _content;

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
        _content = GameObject.Find("Content").GetComponent<Transform>();

        _levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level01"));
        _levelsList.Add(new LevelBlueprint(levelButtonPrefab, "Level02"));

        CreateButtonLevel();
    }

    public void CreateButtonLevel()
    {
        for (int i = 0; i < _levelsList.Count; i++)
        {
            GameObject gObj = Instantiate(levelButtonPrefab);


            gObj.transform.SetParent(_content);
            Text text = gObj.GetComponentInChildren<Text>();
            text.text = _levelsList[i].indexName;
            //Чтобы не было замыкания цыкла
            var selectValueName = _levelsList[i].indexName;
            gObj.GetComponent<Button>().onClick.AddListener(delegate { Select(selectValueName); });
        }
    }

    public void Select(string value)
    {
        SceneManager.LoadScene(value);
    }
}
