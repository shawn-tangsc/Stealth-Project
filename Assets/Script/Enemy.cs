using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public bool isPlayerInSign = false;
    public Vector3 targetPos = Vector3.zero;
    public float angleOfView = 110f;
    private Animator animator;
    private SphereCollider SphereCollider;
    private NavMeshAgent agent;
    private Vector3 preLastPosition;
    private PlayerHealth health;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        SphereCollider = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();

        preLastPosition = GameController._instance.playerPosition;
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		if(GameController._instance.playerPosition != preLastPosition) {

            targetPos = GameController._instance.playerPosition; 
            preLastPosition = GameController._instance.playerPosition;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Tags.player) {
            Vector3 playerPos = other.transform.position - transform.position;
            Vector3 currentPos = transform.forward;
            float angle = Vector3.Angle(playerPos, currentPos);
            if(angle < angleOfView * 0.5f) {
            
                //isPlayerInSign = true;
                ////animator.SetBool("isPlayerInSign", true);
                //GameController._instance.SeePlayer(other.transform);
                Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.green);
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y +1, transform.position.z) , other.transform.position - transform.position, out hit))
                {

                    if (hit.collider.tag == Tags.player && health.HP>0)
                    {
                        isPlayerInSign = true;
                        //animator.SetBool("isPlayerInSign", true);
                        GameController._instance.SeePlayer(other.transform);

                    }
                    else
                    {
                      
                        isPlayerInSign = false;
                        animator.SetBool("isPlayerInSign", false);
                    }
                }
                else
                {
                    isPlayerInSign = false;
                    animator.SetBool("isPlayerInSign", false);
                }

            }
            else {
                isPlayerInSign = false;
                animator.SetBool("isPlayerInSign", false);
            }


            Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("cLocalmotion")) {
            
                NavMeshPath path = new NavMeshPath();

                if (agent.CalculatePath(other.transform.position, path)) {
                    Vector3[] arr = new Vector3[path.corners.Length + 2];
                    arr[0] = transform.position;
                    arr[arr.Length - 1] = other.transform.position;
                    for(int i =0; i < path.corners.Length; i++) {
                        arr[i + 1] = path.corners[i];
                    }

                    float length = 0;

                    for(int i = 1; i < arr.Length; i++) {
                        length += (arr[i] - arr[i - 1]).magnitude;
                    
                    }

                    if (length <= SphereCollider.radius) {
                       
                        targetPos = other.transform.position;
                   
                    }


                }
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == Tags.player) {
            isPlayerInSign = false;
            animator.SetBool("isPlayerInSign", false);
        }
    }
}
