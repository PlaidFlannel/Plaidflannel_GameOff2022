using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    [SerializeField] GameObject ball;
    public bool goalReached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            Debug.Log("reached goal");
            goalReached = true;
        }
    }
}
