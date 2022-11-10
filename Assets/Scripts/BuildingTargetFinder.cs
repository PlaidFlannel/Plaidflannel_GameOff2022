using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class BuildingTargetFinder : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    [SerializeField] bool firesAtEnemies = true;
    
    Transform target;
    private void Start()
    {

    }
    void Update()
    {
        var emission = projectileParticles.emission;
        if (gameObject.GetComponent<CheckBuildPlacement>().isPlaced)
        {
            emission.enabled = true;
            if (firesAtEnemies) { FindClosestEnemyTarget(); }
            else { FindPlayerObject(); }
            
            AimWeapon();
        }
        else
        {
             emission.enabled = false;
        }

    }

    private void FindPlayerObject()
    {
        PlayerObjectHealth playerObject = FindObjectOfType<PlayerObjectHealth>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        float targetDistance = Vector3.Distance(transform.position, playerObject.transform.position);
        if (targetDistance < maxDistance)
        {
            closestTarget = playerObject.transform;
            maxDistance = targetDistance;
        }
        target = closestTarget;
    }

    void FindClosestEnemyTarget()
    {
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyAI enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
