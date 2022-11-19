using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

   // EnemyAI enemyAI;
    //GameObject enemy;
    public bool goal;

    Bank bank;
    GameObject[] allEnemies;
    private EnemyAI enemyController;

    PlayerMovement playerMovement;

    public bool level1Complete = false;
    public bool level2Complete = false;
    public bool level3Complete = false;

    static public GameManager instance;
    ScoreKeeper scoreKeeper;
    //LevelCompleteMenu levelCompleteMenu;
    UIController UIController;

    private void Awake()
    {
        ManageSingleton();
        
        //Debug.Log(levelCompleteMenu);
        //levelMenu = levelCompleteMenu.GetComponent<GameObject>();
        //levelMenu.gameObject.SetActive(true);
    }
    void Start()
    {
        UIController = FindObjectOfType<UIController>();
        //levelCompleteMenu = FindObjectOfType<LevelCompleteMenu>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        bank = FindObjectOfType<Bank>();
        
        playerMovement = FindObjectOfType<PlayerMovement>();
        
        ////bottomUI.gameObject.SetActive(true);
        ////gameOverText.gameObject.SetActive(false);


        //levelMenu.gameObject.SetActive(false);
        //goal = FindObjectOfType<Goal>().goalReached;
        
    }


    void Update()
    {
        if (goal == true)
        {
            LevelComplete();
        }
        //if (goal != true) { Debug.Log("not reached"); }

    }

    private void LevelComplete()
    {
        //levelCompleteMenu.LevelCompleteMenuDisplay();
        goal = false;
        Debug.Log("gamemanager sees the goal");
        scoreKeeper.ModifyGold(bank.CurrentBalance);

        //gameOverText.gameObject.SetActive(true);


        //bottomUI.gameObject.SetActive(false);
        UIController.BottomUIDisplayToggle();
        UIController.LevelCompleteMenuDisplayToggle();
        playerMovement.enabled = false;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach (GameObject enemy in allEnemies)
        {
            
            enemyController = enemy.GetComponent<EnemyAI>();
            if (enemyController.enabled) { enemyController.enabled = false; Debug.Log("1 enemy disabled"); }


        }

        //levelMenu.gameObject.SetActive(true);
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetGameSession()
    {
        //currentScene = 
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
