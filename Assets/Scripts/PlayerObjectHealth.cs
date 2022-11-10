using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjectHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] float healingItemHitValue = 15f;

    
    private void Start()
    {
        healthDisplay.text = "Health: " + health.ToString() + "%";
        //healthDisplay = GetComponent<TextMeshProUGUI>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
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
            Debug.Log("HealthUp" + health);
            ProcessHealthUpHit(healingItemHitValue);
        }
    }
    void ProcessHealthUpHit(float healingValue)
    {
        health += healingValue;

    }
}
