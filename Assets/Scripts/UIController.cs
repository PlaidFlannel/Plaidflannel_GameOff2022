using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject bottomUI;
    [SerializeField] GameObject levelCompleteMenu;
    //[SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject inGameMenu;
    [SerializeField] Button restartLevelButton;
    [SerializeField] Button cameraLButton;
    [SerializeField] Button cameraRButton;

    [Header("Level Complete Buttons")]
    [SerializeField] Button mainMenu;
    [SerializeField] Button nextLevel;

    GameManager gameManager;
    RotateCamera rotateCamera;

    //bool levelComplete;
    //test 
    //LevelCompleteMenu lcm;
    void Start()
    {
        rotateCamera = FindObjectOfType<RotateCamera>();
        gameManager = FindObjectOfType<GameManager>();
        inGameMenu.SetActive(false);
        bottomUI.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(false);

        levelCompleteMenu.gameObject.SetActive(false );

        //levelComplete = gameManager.goal;
        AddButtonListeners();

    }
    void Update()
    {
        if (gameManager.gameManagerGoal)
        {
            //Debug.Log("level complete in UIController");
            LevelCompleteMenuDisplayToggle();
            BottomUIDisplayToggle();
        }
        //restartLevelButton.  
    }
    private void AddButtonListeners()
    {
        restartLevelButton.onClick.AddListener(gameManager.ReloadLevel);
        cameraLButton.onClick.AddListener(rotateCamera.RotateCameraLeft);
        cameraRButton.onClick.AddListener(rotateCamera.RotateCameraRight);
        mainMenu.onClick.AddListener(ToMainMenu);
        nextLevel.onClick.AddListener(ToNextLevel);
    }

    private void ToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(currentSceneIndex);
        gameManager.LoadScene("Level" + nextSceneIndex);
    }
    private void ToMainMenu()
    {
        gameManager.LoadScene("MainMenu");
    }
    // Update is called once per frame

    public void LevelCompleteMenuDisplayToggle()
    {
        if(levelCompleteMenu != null)
        {
            levelCompleteMenu.gameObject.SetActive(true);
        }
    }
    public void BottomUIDisplayToggle()
    {
        if(bottomUI != null)
        {
            //if (bottomUI.gameObject.activeSelf)
            //{
                bottomUI.gameObject.SetActive(false);
            ///}
            //else
            //{
             //   bottomUI.gameObject.SetActive(true);
            //}
        }
    }
}
