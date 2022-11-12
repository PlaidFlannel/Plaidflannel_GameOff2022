using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerObjectHealth target;
    [SerializeField] float damage = 0.5f;
    void Start()
    {
        target = FindObjectOfType<PlayerObjectHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        //Debug.Log("WHAM");
    }


}
