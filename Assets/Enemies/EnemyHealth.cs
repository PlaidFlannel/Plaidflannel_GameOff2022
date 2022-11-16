using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] AudioClip takingDamage;
    [SerializeField] Material normalMaterial;
    [SerializeField] Material damageMaterial;
    [SerializeField] MeshRenderer[] bodyParts;

    [SerializeField] GameObject coinDrop;

    private float changeColorTime = .5f;

    private int damageFromArrow;
    private int damageFromCannonBall;

    BuildingManager buildingManager;

    [SerializeField] int currentHitPoints = 0;

    AudioSource audioSource;

    public bool isDead = false;
    ScoreKeeper scoreKeeper;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        audioSource = GetComponent<AudioSource>();
        //Vector3 startLocation = transform.position;
        buildingManager = FindObjectOfType<BuildingManager>();
        damageFromArrow = buildingManager.damageFromBallista;
        damageFromCannonBall = buildingManager.damageFromCannon;
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particle hit" + name);
        if (other.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(ChangeColor());
            //gameObject.GetComponentInChildren<MeshRenderer>().material = damageMaterial;
            //Debug.Log("Arrow Hit" + currentHitPoints);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(takingDamage);
            }
            ProcessHit(damageFromArrow);
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            StartCoroutine(ChangeColor());
            //Debug.Log("CannonBall Hit" + currentHitPoints);
            ProcessHit(damageFromCannonBall);
            if (audioSource.enabled && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(takingDamage);
            }
        }

    }

    IEnumerator ChangeColor()
    {
        foreach(MeshRenderer i in bodyParts)
        {
            i.material = damageMaterial;
        }
        //gameObject.GetComponentInChildren<MeshRenderer>().material = damageMaterial;
        yield return new WaitForSeconds(changeColorTime);
        foreach (MeshRenderer i in bodyParts)
        {
            i.material = normalMaterial;
        }
        //gameObject.GetComponentInChildren<MeshRenderer>().material = normalMaterial;
    }


    void ProcessHit(int damage)
    {
        currentHitPoints -= damage;
        
        if (currentHitPoints <= 0)
        {
            scoreKeeper.ModifyEnemiesDefeated(1);
            isDead = true;
            audioSource.Stop();
            Instantiate(coinDrop, transform.position, coinDrop.transform.rotation);
            gameObject.SetActive(false);
            //enemy.RewardGold();
            //maxHitPoints += difficultyRamp;
        }
    }

}
