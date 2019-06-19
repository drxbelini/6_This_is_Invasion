using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;  
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float targetDistance = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {        
        chaseRangeLogic();
    }

    private void chaseRangeLogic()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        
        if (isProvoked)
        {
            engageChase();
        }
        else if (targetDistance <= chaseRange)
        {
            isProvoked = true;
        }             
    }

    private void engageChase()
    {
        if (targetDistance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.isStopped = true;
            print ("atack");
        }
        else
        {
            chasingTarget();   
        }
                 
    }

    private void chasingTarget()
    {   
        navMeshAgent.isStopped = false;
        navMeshAgent.destination = target.position;
    }

    void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
