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
    
    [SerializeField] Button restartLevelButton;
    [SerializeField] Button cameraLButton;
    [SerializeField] Button cameraRButton;
    [SerializeField] TextMeshProUGUI playerObjectHealthDisplay;
    //setup mute button
    [Header("Level Complete Buttons")]
    [SerializeField] Button mainMenu;
    [SerializeField] Button nextLevel;
    [Header("In Game Menu Buttons")]
    [SerializeField] GameObject inGameMenu;
    [SerializeField] Button soundsToggleButton;

    GameManager gameManager;
    RotateCamera rotateCamera;
    PlayerObjectHealth playerObjectHealth;
    AudioListener audioListener;
    ScoreKeeper scoreKeeper;
    Button audioButton;
    //bool levelComplete;
    //test 
    //LevelCompleteMenu lcm;
    void Start()
    {
        audioButton = soundsToggleButton.GetComponent<Button>();
        audioListener = FindObjectOfType<AudioListener>();
        playerObjectHealth = FindObjectOfType<PlayerObjectHealth>();

        playerObjectHealthDisplay.text = "Health: " + playerObjectHealth.health.ToString() + "%";
        rotateCamera = FindObjectOfType<RotateCamera>();
        gameManager = FindObjectOfType<GameManager>();
        inGameMenu.SetActive(false);
        bottomUI.gameObject.SetActive(true);

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelCompleteMenu.gameObject.SetActive(false );


        AddButtonListeners();
        if (gameManager.audioListenerIsEnabled == false)
        {
            //if (!AudioListener.pause) {
            audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sounds Off";
            AudioListener.pause = true;
        }

    }
    void Update()
    {
        playerObjectHealthDisplay.text = "Health: " + playerObjectHealth.health.ToString() + "%";
        if (gameManager.gameManagerGoal)
        {
            LevelCompleteMenuDisplayToggle();
            BottomUIDisplayToggle();
        }
        if (gameManager.audioListenerIsEnabled == false)
        {
            //if (!AudioListener.pause) {
            audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sounds Off";
            AudioListener.pause = true;
        }
    }
    private void AddButtonListeners()
    {
        restartLevelButton.onClick.AddListener(gameManager.ReloadLevel);
        cameraLButton.onClick.AddListener(rotateCamera.RotateCameraLeft);
        cameraRButton.onClick.AddListener(rotateCamera.RotateCameraRight);
        mainMenu.onClick.AddListener(ToMainMenu);
        nextLevel.onClick.AddListener(ToNextLevel);
        soundsToggleButton.onClick.AddListener(MuteAudioToggle);
        
    }
    private void MuteAudioToggle()
    {
        if (gameManager.audioListenerIsEnabled == true) {
        //if (!AudioListener.pause) {
            audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sounds Off";
            AudioListener.pause = true;
            gameManager.audioListenerIsEnabled = false;
        }
            

        else {
            audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sounds On";
            gameManager.audioListenerIsEnabled = true;
            AudioListener.pause = false; }
            
    }
    private void ToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        gameManager.LoadScene("Level" + nextSceneIndex);
    }
    public void ToMainMenu()
    {
        scoreKeeper.ResetScores();
        gameManager.LoadScene("MainMenu");
    }

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
            bottomUI.gameObject.SetActive(false);
        }
    }
}
