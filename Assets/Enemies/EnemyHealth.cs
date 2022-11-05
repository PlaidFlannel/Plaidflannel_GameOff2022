using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    /*
    [SerializeField] float health = 100f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //destroy or set inactive...
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }*/
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amount to max hitHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    //EnemyAI enemyAI;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        //enemyAI = GetComponent<EnemyAI>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit" + name);
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            //enemy.RewardGold();
            maxHitPoints += difficultyRamp;
        }
    }
}
