using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;
    private NavMeshAgent agent;
    private float walkSpeed = 0.3f;
    private float angleSpeed = 0.3f;
    private Enemy enemy;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.nextPosition = transform.position;
        enemy = GetComponent<Enemy>();
    }

    void Start()
    {
        //anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        //agent.
    }

    // Update is called once per frame
    void Update()
    {

        if(agent.desiredVelocity == Vector3.zero)
        {
            anim.SetFloat("Speed", 0, walkSpeed,Time.deltaTime);
            anim.SetFloat("AngleSpeed", 0, angleSpeed, Time.deltaTime);
 
        }
        else {
            agent.nextPosition = transform.position;
            //先用期望的速率和本身的朝向求夹角
            float angle = Vector3.Angle(agent.desiredVelocity, transform.forward);
            float angleRad = angle * Mathf.Deg2Rad;


            Vector3 cross = Vector3.Cross(transform.forward, agent.desiredVelocity);


            if (cross.y < 0)
            {
                angleRad *= -1;
            }
            //print("angle" + angle);
            //print("angleRad" + angleRad);
            anim.SetFloat("AngleSpeed", angleRad, angleSpeed, Time.deltaTime);


            if (angle > 60)
            {
                anim.SetFloat("Speed", 0, walkSpeed, Time.deltaTime);

            }
            else
            {

                Vector3 projection = Vector3.Project(agent.desiredVelocity, transform.forward);
                anim.SetFloat("Speed", projection.magnitude, walkSpeed, Time.deltaTime);

            }

          




        }

        anim.SetBool("isPlayerInSign", enemy.isPlayerInSign);
    }
}
