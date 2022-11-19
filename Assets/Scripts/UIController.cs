using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject bottomUI;
    [SerializeField] GameObject levelCompleteMenu;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject inGameMenu;
    [SerializeField] Button restartLevelButton;

    GameManager gameManager;

    //test 
    //LevelCompleteMenu lcm;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        inGameMenu.SetActive(false);
        bottomUI.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        levelCompleteMenu.gameObject.SetActive(false );
        restartLevelButton.onClick.AddListener(gameManager.ReloadLevel);


    }

    // Update is called once per frame
    void Update()
    {
        //restartLevelButton.  
    }
    public void LevelCompleteMenuDisplayToggle()
    {
        if(levelCompleteMenu != null)
        {
            if (levelCompleteMenu.gameObject.activeSelf)
            {
                levelCompleteMenu.gameObject.SetActive(false);
            }
            else
            {
                levelCompleteMenu.gameObject.SetActive(true);
            }
        }
    }
    public void BottomUIDisplayToggle()
    {
        if(bottomUI != null)
        {
            if (bottomUI.gameObject.activeSelf)
            {
                bottomUI.gameObject.SetActive(false);
            }
            else
            {
                bottomUI.gameObject.SetActive(true);
            }
        }
    }
}
