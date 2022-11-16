using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    [SerializeField] GameObject ball;
    public bool goalReached = false;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            gameManager.goal = true;
            //Debug.Log("reached goal");
            goalReached = true;
        }
    }
}
