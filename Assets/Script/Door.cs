using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int count = 0;
    public AudioSource audioOpen;
    public AudioSource audioOpenDenied;
    private Animator anim;

    public bool requireKey = false;

	// Use this for initialization
	void Start () {
    
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

       

        anim.SetBool("isClose", count <= 0);
        if (anim.IsInTransition(0))
        {
        
            if (!audioOpen.isPlaying) {
       
                audioOpen.Play();
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Enemy" || other.tag == Tags.player) {
        if (requireKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.hasKey == true)
                {
                    count++;
                }
                else
                {
                    if (!audioOpenDenied.isPlaying)
                    {
                        audioOpenDenied.Play();
                    }
                }
           }
  
        }
        else {
            //if()
            if(other.tag == Tags.player || (other.tag == Tags.enemy && !other.GetComponent<Collider>().isTrigger))
            {
                count++;

            }

        }

        //}
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == Tags.enemy || other.tag == Tags.player)
        {
          
            if (count > 0)
            {
                count--;
            }
        }
    }
}
