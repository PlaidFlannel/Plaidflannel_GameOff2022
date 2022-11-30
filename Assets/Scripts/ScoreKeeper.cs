using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public int goldTotal;
    public float ballHealthFinal; //remaining percent
    public int enemiesDefeated;

    //Level 1 score
    public int level1GoldTotal;
    public float level1BallHealthFinal;
    public int level1EnemiesDefeated;
    //Level 2 score
    public int level2GoldTotal;
    public float level2BallHealthFinal;
    public int level2EnemiesDefeated;
    //Level 3 score
    public int level3GoldTotal;
    public float level3BallHealthFinal;
    public int level3EnemiesDefeated;

    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
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

    public int GetScore()
    {
        return score;
    }
    public int GetGold()
    {
        return goldTotal;
    }
    public float GetHealth()
    {
        return ballHealthFinal;
    }
    public int GetEnemiesDefeated()
    {
        return enemiesDefeated;
    }
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ModifyGold(int value)
    {
        goldTotal += value;
        Mathf.Clamp(goldTotal, 0, int.MaxValue);
        Debug.Log(goldTotal);
    }
    public void ModifyEnemiesDefeated(int value)
    {
        enemiesDefeated += value;
        Mathf.Clamp(enemiesDefeated, 0, int.MaxValue);
        Debug.Log("enemies defeated: " + enemiesDefeated);
    }
    public void ModifyHealth(float value)
    {
        ballHealthFinal += value;
        //Mathf.Clamp(ballHealthFinal, 0, float.MaxValue);
        //Debug.Log(ballHealthFinal);
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void SaveScores()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1) 
        {
            level1GoldTotal = goldTotal;
            level1BallHealthFinal = ballHealthFinal;
            level1EnemiesDefeated = enemiesDefeated;
        }
        if (currentSceneIndex == 2)
        {
            level2GoldTotal = goldTotal;
            level2BallHealthFinal = ballHealthFinal;
            level2EnemiesDefeated = enemiesDefeated;
        }
        if (currentSceneIndex == 3)
        {
            level3GoldTotal = goldTotal;
            level3BallHealthFinal = ballHealthFinal;
            level3EnemiesDefeated = enemiesDefeated;
        }

    }
    public void ResetScores()
    {

        goldTotal = 0;
        ballHealthFinal = 0;
        enemiesDefeated = 0;
    }
}
