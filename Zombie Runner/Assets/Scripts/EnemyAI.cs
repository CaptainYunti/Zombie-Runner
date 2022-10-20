using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if(health.IsDead())
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            ChasingPlayer();
        }


    }

    private void ChasingPlayer()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }


    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget > navMeshAgent.stoppingDistance)
        {
            animator.SetBool("attack", false);
            ChaseTarget();
        }
        
        else
        {
            animator.SetBool("attack", true);
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log("Die you little bitch"); 
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
