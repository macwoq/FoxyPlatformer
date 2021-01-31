using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public Transform[] patrolPionts;
    public int currentPatrolPoint;

    public NavMeshAgent agent;

    public Animator anim;

    public enum AIState
    {
        isIdle, isPatrolling, isChasing, isAttacking
    };
    public AIState currentState;

    public float waitAtPoint = 2f;
    private float waitCounter;

    public float chaseRange;

    public float attckRrange = 1f;





    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);


        switch (currentState)
        {
            case AIState.isIdle:
                anim.SetBool("IsMoving", false);
                if(waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.isPatrolling;
                    agent.SetDestination(patrolPionts[currentPatrolPoint].position);
                }

                if(distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                    anim.SetBool("IsMoving", true);
                }


                break;

            case AIState.isPatrolling:

                //agent.SetDestination(patrolPionts[currentPatrolPoint].position);

                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPionts.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    //agent.SetDestination(patrolPionts[currentPatrolPoint].position);
                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint;
                }

                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                }

                anim.SetBool("IsMoving", true);

                break;

            case AIState.isChasing:

                agent.SetDestination(PlayerController.instance.transform.position);

                //if(distanceToPlayer <= attckRrange)
                //{
                //    currentState = AIState.isAttacking;
                //    anim.SetTrigger("Attack");
                //    anim.SetBool("IsMoving", false);
                //
                //    agent.velocity = Vector3.zero;
                //    agent.isStopped = true;
                //}
                if(distanceToPlayer > attckRrange)
                {
                    currentState = AIState.isPatrolling;
                    waitCounter = waitAtPoint;
                }
                break;

            
        }
    }
}
