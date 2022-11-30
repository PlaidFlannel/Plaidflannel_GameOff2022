using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class PlayerObjectHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 150f;
    public bool needsHealth = false;
    //[SerializeField] float deathReloadDelay = 2.5f;
    [SerializeField] float healingItemHitValue = 15f;

    [SerializeField] AudioClip healthIncoming;
    [SerializeField] AudioClip takingDamage;
    
    [SerializeField] Material normalMaterial;
    [SerializeField] Material damageMaterial;
    private float changeColorTime = .5f;

    AudioSource audioSource;
    GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (health < maxHealth)
        {
            needsHealth = true;
        }
        else { needsHealth = false; }
    }
    public void TakeDamage(float damage)
    {
        StartCoroutine(ChangeColor());
        health -= damage;
        audioSource.PlayOneShot(takingDamage);
        if (health <= 0)
        {
            gameManager.DelayedReloadLevel();

            Destroy(gameObject);
        }
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("HealthUp"))
        {
            audioSource.PlayOneShot(healthIncoming);

            ProcessHealthUpHit(healingItemHitValue);
        }
    }
    void ProcessHealthUpHit(float healingValue)
    {
        if (health + healingValue <= maxHealth )
        {
            health += healingValue;
        }
        if (health + healingValue >= maxHealth)
        {
            health = maxHealth;
        }
    }
    /*
    IEnumerator ProcessDeath()
    {
        Debug.Log("playerObjectHealth processDeath");
        yield return new WaitForSeconds(deathReloadDelay);
        gameManager.ReloadLevel();
    }*/
    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material = damageMaterial;
        
        yield return new WaitForSeconds(changeColorTime);
       
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
    }
}
