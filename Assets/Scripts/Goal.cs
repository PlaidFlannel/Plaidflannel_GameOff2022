using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    [SerializeField] GameObject ball;
    public bool goalReached = false;
    GameManager gameManager;
    PlayerObjectHealth ballHealth;
    ScoreKeeper scoreKeeper;
    //BoxCollider boxCollider;
    [SerializeField] int currentLevel;
    private void Start()
    {
        ballHealth = FindObjectOfType<PlayerObjectHealth>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Goal triggered");
        //if (other.gameObject == ball)
        if(other.tag == "Ball")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 1) { gameManager.level1Complete = true; }
            if (currentSceneIndex == 2) { gameManager.level2Complete = true; }
            if (currentSceneIndex == 3) { gameManager.level3Complete = true; }

            scoreKeeper.ModifyHealth(ballHealth.health);
            gameManager.gameManagerGoal = true;
            gameManager.level1Complete = true ;
            goalReached = true;
            //Debug.Log("goalReached: " + goalReached);

        }
    }
}
