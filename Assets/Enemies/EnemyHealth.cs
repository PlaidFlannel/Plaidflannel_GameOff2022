using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    //[SerializeField] int damageFromArrow = 1;
    //[SerializeField] int damageFromCannonBall = 2;
    private int damageFromArrow;
    private int damageFromCannonBall;
    //[Tooltip("Adds amount to max hitHitPoints when enemy dies")]
    //[SerializeField] int difficultyRamp = 1;
    BuildingManager buildingManager;

    int currentHitPoints = 0;



    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        Vector3 startLocation = transform.position;
        buildingManager = FindObjectOfType<BuildingManager>();
        damageFromArrow = buildingManager.damageFromBallista;
        damageFromCannonBall = buildingManager.damageFromCannon;
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particle hit" + name);
        if (other.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("Arrow Hit" + currentHitPoints);
            ProcessHit(damageFromArrow);
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Debug.Log("CannonBall Hit" + currentHitPoints);
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
