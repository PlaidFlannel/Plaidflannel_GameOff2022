using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameManagerGoal;
    public bool gameActive;

    [SerializeField] float reloadDelay = 1.0f;

    public bool level1Complete = false;
    public bool level2Complete = false;
    public bool level3Complete = false;
    [SerializeField] AudioClip levelCompleteAudio;
    [SerializeField] AudioClip levelFailedAudio;
    ScoreKeeper scoreKeeper;
    Bank bank;
    AudioSource audioSource;
    AudioListener audioListener;
    static public GameManager instance;
    public bool audioListenerIsEnabled = true;
    private void Awake()
    {
        ManageSingleton();
    }
    void Start()
    {
        audioListener = GetComponent<AudioListener>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioSource = GetComponent<AudioSource>();
        gameActive = true;
    }

    void Update()
    {
        if (gameManagerGoal == true)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        if (audioListenerIsEnabled) { audioSource.PlayOneShot(levelCompleteAudio); }

        bank = FindObjectOfType<Bank>();
        gameManagerGoal = false;
        gameActive = false;
        scoreKeeper.ModifyGold(bank.CurrentBalance);
        scoreKeeper.SaveScores();

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
        if (audioListenerIsEnabled) { audioSource.PlayOneShot(levelFailedAudio); }

        StartCoroutine(ReloadWithDelay()); 
    }
    IEnumerator ReloadWithDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        ReloadLevel();
    }
}
