using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameManagerGoal;
    public bool gameActive;
    [SerializeField] float reloadDelay = 1.0f;
    //GameObject[] allEnemies;
    //private EnemyAI enemyController;

    public bool level1Complete = false;
    public bool level2Complete = false;
    public bool level3Complete = false;

    ScoreKeeper scoreKeeper;
    Bank bank;
    // UIController UIController;
    //Goal goal;
    //PlayerMovement playerMovement;

    static public GameManager instance;
    private void Awake()
    {
        ManageSingleton();
    }
    void Start()
    {
        //Debug.Log("gamemanager start");
        //UIController = FindObjectOfType<UIController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        bank = FindObjectOfType<Bank>();
        gameActive = true;
        //playerMovement = FindObjectOfType<PlayerMovement>();
      
    }

    void Update()
    {
        //Debug.Log("monitoring gameManagerGoal " + gameManagerGoal);
        if (gameManagerGoal == true)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Debug.Log("level complete in gamemanager");
        gameManagerGoal = false;
        gameActive = false;
        //Debug.Log("gamemanager sees the goal");
        scoreKeeper.ModifyGold(bank.CurrentBalance);
        //UIController.BottomUIDisplayToggle();
        //UIController.LevelCompleteMenuDisplayToggle();
        //playerMovement.enabled = false;
        //allEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        //disables EnemyAI to stop enemies from further attacking the playerObject
        /*foreach (GameObject enemy in allEnemies)
        {
            enemyController = enemy.GetComponent<EnemyAI>();
            if (enemyController.enabled) 
            { 
                enemyController.enabled = false; Debug.Log("1 enemy disabled"); 
            }
        }*/
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       // Debug.Log("scene " + currentSceneIndex + " completed step 2");
        //if (currentSceneIndex == 1) { level1Complete = true;}
        //if (currentSceneIndex == 2) { level2Complete = true; }
        //if (currentSceneIndex == 3) { level3Complete = true; }
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
        //goal = FindObjectOfType<Goal>();
       // Debug.Log("found it" + goal);
    }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void DelayedReloadLevel() 
    {
        //Debug.Log("delay reload step 1");
        StartCoroutine(ReloadWithDelay()); 
    }
    IEnumerator ReloadWithDelay()
    {
        //Debug.Log("reloading with delay");
        yield return new WaitForSeconds(reloadDelay);
        ReloadLevel();
    }
}
