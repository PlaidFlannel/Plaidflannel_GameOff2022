using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //[SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    //[SerializeField] bool isActive = true;
    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    GameObject targetObject;
    Transform target;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //Transform target = GetComponent<PlayerObjectHealth>().transform;
        targetObject = GameObject.FindWithTag("Ball");
        target = targetObject.transform;
    }


    void Update()
    {
        if (target == null) { GetComponent<Animator>().SetTrigger("idle"); }
        if (target != null)
        {
            CheckDistance();

            if (isProvoked)
            {
                EngageTarget();

            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;
            }
        }
    }

    private void CheckDistance()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        //Debug.Log(name + "is attacking" + target.name);
    }
    private void OnDrawGizmosSelected()
    {
        //Display the enemy chaseRange radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
