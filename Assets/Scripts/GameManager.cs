using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    
   // EnemyAI enemyAI;
    //GameObject enemy;
    Goal goal;
    GameObject[] allEnemies;
    private EnemyAI enemyController;

    void Start()
    {
        //Enemy[] enemyAIObjs = FindObjectsOfType<Enemy>();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        gameOverText.gameObject.SetActive(false);
        goal = FindObjectOfType<Goal>();
    }


    void Update()
    {
        if (goal.goalReached)
        {
            
            gameOverText.gameObject.SetActive(true);
            //Debug.Log("gamemanager sees the goal");
            foreach (GameObject enemy in allEnemies)
            {

                enemyController = enemy.GetComponent<EnemyAI>();
                if (enemyController.enabled) { enemyController.enabled = false; Debug.Log("1 enemy disabled"); }
                
                
            }
            //goal.goalReached = false;
        }
    }

}
