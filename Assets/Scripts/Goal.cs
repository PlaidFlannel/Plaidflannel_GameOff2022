using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    [SerializeField] GameObject ball;
    public bool goalReached = false;
    GameManager gameManager;
    PlayerObjectHealth ballHealth;
    ScoreKeeper scoreKeeper;
    BoxCollider boxCollider;
    private void Start()
    {
        ballHealth = FindObjectOfType<PlayerObjectHealth>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Goal triggered");
        //if (other.gameObject == ball)
        if(other.tag == "Ball")
        {
            //boxCollider.enabled = false;
            Debug.Log(ballHealth.health);
            scoreKeeper.ModifyHealth(ballHealth.health);
            gameManager.goal = true;
            //Debug.Log("reached goal");
            goalReached = true;
        }
    }
}
