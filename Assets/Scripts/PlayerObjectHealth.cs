using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjectHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 150f;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] float healingItemHitValue = 15f;

    [SerializeField] AudioClip healthIncoming;
    [SerializeField] AudioClip takingDamage;
    //[SerializeField] AudioClip rolling;

    AudioSource audioSource;

    
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        healthDisplay.text = "Health: " + health.ToString() + "%";

    }
    private void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        audioSource.PlayOneShot(takingDamage);
        healthDisplay.text = "Health: " + health.ToString() + "%";
        if (health <= 0)
        {
            //destroy or set inactive...
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particle hit" + name);
        if (other.gameObject.CompareTag("HealthUp"))
        {
            audioSource.PlayOneShot(healthIncoming);
            //Debug.Log("HealthUp" + health);
            ProcessHealthUpHit(healingItemHitValue);
        }
    }
    void ProcessHealthUpHit(float healingValue)
    {
        if (health < maxHealth)
        {
            health += healingValue;
            healthDisplay.text = "Health: " + health.ToString() + "%";
        }

    }
}
