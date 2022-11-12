using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBuildingTargetFinder : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    //[SerializeField] ParticleSystem projectileParticles2;
    [SerializeField] float range = 15f;


    [SerializeField] AudioClip firingAudio;
    [SerializeField] float soundDelay = 0.2f;
    private int currentNUmberOfParticles = 0;


    PlayerObjectHealth playerObject;
    AudioSource audioSource;
    Transform target;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerObject = FindObjectOfType<PlayerObjectHealth>();
    }
    void Update()
    {
        var emission = projectileParticles.emission;
        if (gameObject.GetComponent<CheckBuildPlacement>().isPlaced)
        {
            emission.enabled = true;


            if (playerObject != null) 
            { 
                 FindPlayerObject();
                 AimWeapon();
            } 

        }

        else
        {
            emission.enabled = false;
        }
        //var amount = MathF.Abs(currentNUmberOfParticles - projectileParticles.particleCount);
        if (projectileParticles.particleCount < currentNUmberOfParticles)
        {
            //Can play a sound when the particle is 'dead' also
            //StartCoroutine(PlaySound(particleDead, soundDelay);
            //Debug.Log("particle dead?");
        }
        if (projectileParticles.particleCount > currentNUmberOfParticles)
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


    private void FindPlayerObject()
    {


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


    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range && playerObject.health + 1 < playerObject.maxHealth)
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
