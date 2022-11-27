using System;
using System.Collections;
using System.Collections.Generic;
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
    GameManager gameManager;
    EnemyAI enemyAI;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        buildingManager = FindObjectOfType<BuildingManager>();
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        enemyAI = GetComponent<EnemyAI>();
        audioSource = GetComponent<AudioSource>();
        damageFromArrow = buildingManager.damageFromBallista;
        damageFromCannonBall = buildingManager.damageFromCannon;
    }
    private void Update()
    {
        if (gameManager.gameManagerGoal)
        {
            Debug.Log("enemy health sees the goal");
            enemyAI.enabled = false;
        }
    }
    void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(ChangeColor());
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(takingDamage);
            }
            ProcessHit(damageFromArrow);
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            StartCoroutine(ChangeColor());
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
        yield return new WaitForSeconds(changeColorTime);
        foreach (MeshRenderer i in bodyParts)
        {
            i.material = normalMaterial;
        }
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
