using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform[] wayPoint;
    private int index = 0;
    private NavMeshAgent agent;
    public float stayTimeSdr = 3f;
    private float stayTime = 0;
    public float chaseTime = 3;
    private float chaseTimer = 0;
    private Animator anim;
    private PlayerHealth health;

    private Enemy enemy;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = wayPoint[index].position;
        agent.updatePosition = false;
        agent.updateRotation = false;
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isPlayerInSign&& health.HP>0)
        {
            Shoot();
        }
        else if (enemy.targetPos != Vector3.zero && health.HP > 0)
        {
            Chaseing();
            stayTime = 0;
            anim.SetBool("isPlayerInSign", false);
        }
        else
        {
            GoOnPatrol();
            anim.SetBool("isPlayerInSign", false);
        }


    }

    private void Shoot() {
        agent.isStopped = true;
    
    }
    private void Chaseing() {
        agent.isStopped = false;
        agent.speed =6;
        agent.SetDestination(enemy.targetPos) ;
        agent.updatePosition = false;
        agent.updateRotation = false;
        if (agent.remainingDistance < 2)
        {

            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseTime)
            {
                enemy.targetPos = Vector3.zero;

                GameController._instance.alermOn = false;
                chaseTimer = 0;

            }

        }
    }

    private void GoOnPatrol() {
        agent.isStopped = false;
        agent.speed = 2.5f;
        if(agent.remainingDistance < 0.05f) {
            //agent.Stop();
            stayTime += Time.deltaTime;
            if (stayTime>=stayTimeSdr)
            {


                index++;
                index %= 4;
                agent.destination = wayPoint[index].position;
                agent.updatePosition = false;
                agent.updateRotation = false;
                stayTime = 0;

            }
      
          
            
        
        }

    }
}
