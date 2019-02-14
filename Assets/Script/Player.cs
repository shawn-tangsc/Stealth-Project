using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = .1f;
    public float rotateSpeed = 10;
    private Animator anim;
    public bool hasKey = false;

    private AudioSource source;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        source = GetComponent<AudioSource>();
     

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift)) {

            anim.SetBool("isSneak", true);
        }
        else {

            anim.SetBool("isSneak", false);
        }


        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed",v * 2.6f);
        //anim.SetFloat("runRotation", h * 2.3f);
     
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            float newSpeed = Mathf.Lerp(anim.GetFloat("Speed"), 5.6f, moveSpeed * Time.deltaTime);
            anim.SetFloat("Speed", newSpeed);

            Vector3 targetVec = new Vector3(h, 0, v);
            //Vector3 currentVec = transform.forward;
            //print("targetVec:" + targetVec);
            //print("currentVec:" + currentVec);
            //float angle = Vector3.Angle(targetVec, currentVec);
            //print("angle:"+angle);


            //transform.Rotate(Vector3.up * angle * Time.deltaTime*rotateSpeed);


            Quaternion newVec = Quaternion.LookRotation(targetVec, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newVec, rotateSpeed * Time.deltaTime);
        }
        else {
            anim.SetFloat("Speed", 0f);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("cLocalmotion")) {
            startPlayFootMusic();
        }
        else {
            stopPlayFootMusic();


        }
    }

    private void startPlayFootMusic() {
        if (!source.isPlaying) {
            source.Play();
        }
       
    }

    private void stopPlayFootMusic()
    {
        source.Stop();
    }
}
