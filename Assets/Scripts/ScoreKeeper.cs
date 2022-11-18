using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;
    private int goldTotal;
    public float ballHealthFinal; //remaining percent
    private int enemiesDefeated;


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
        Debug.Log(ballHealthFinal);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
