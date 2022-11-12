using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingTargetFinder : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    //[SerializeField] bool firesAtEnemies = true;

    [SerializeField] AudioClip firingAudio;
    [SerializeField] float soundDelay = 0.2f;
    private int currentNUmberOfParticles = 0;

    AudioSource audioSource;
    Transform target;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        var emission = projectileParticles.emission;
        if (gameObject.GetComponent<CheckBuildPlacement>().isPlaced)
        {
            emission.enabled = true;
            FindClosestEnemyTarget(); 
            AimWeapon();
        }

        else
        {
             emission.enabled = false;
        }
        //var amount = MathF.Abs(currentNUmberOfParticles - projectileParticles.particleCount);
        if(projectileParticles.particleCount < currentNUmberOfParticles)
        {
            //Can play a sound when the particle is 'dead' also
            //StartCoroutine(PlaySound(particleDead, soundDelay);
            //Debug.Log("particle dead?");
        }
        if(projectileParticles.particleCount > currentNUmberOfParticles)
        {
            //Plays sound when particle is 'born'
            StartCoroutine(PlaySound(firingAudio, soundDelay));
        }
        currentNUmberOfParticles = projectileParticles.particleCount;
    }

    private IEnumerator PlaySound(AudioClip clip, float soundDelay)
    {
        yield return new WaitForSeconds(soundDelay);
        audioSource.PlayOneShot(clip);
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
