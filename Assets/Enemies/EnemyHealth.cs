using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int damageFromArrow = 1;
    [SerializeField] int damageFromCannonBall = 2;
    //[Tooltip("Adds amount to max hitHitPoints when enemy dies")]
    //[SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;



    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        Vector3 startLocation = transform.position;
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particle hit" + name);
        if (other.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("Arrow Hit");
            ProcessHit(damageFromArrow);
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Debug.Log("CannonBall Hit");
            ProcessHit(damageFromCannonBall);
        }
    }



    void ProcessHit(int damage)
    {
        currentHitPoints -= damage;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            //enemy.RewardGold();
            //maxHitPoints += difficultyRamp;
        }
    }

}
