using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitDoor : MonoBehaviour {

    public Transform outer_left_door;
    public Transform inner_left_door;
    public Transform outer_right_door;
    public Transform inner_right_door;
    public float transSpeed = 1;
    private bool isIn = false;
    public float liftOnDelay = 3;

    public float liftOnTimer = 0;
    public float winTimer = 0;
    private AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        float innerLeftX = Mathf.Lerp(inner_left_door.position.x, outer_left_door.position.x, Time.deltaTime * transSpeed);
        inner_left_door.position = new Vector3(innerLeftX, inner_left_door.position.y, inner_left_door.position.z);
        float innerRightX = Mathf.Lerp(inner_right_door.position.x, outer_right_door.position.x, Time.deltaTime * transSpeed);
        inner_right_door.position = new Vector3(innerRightX, inner_right_door.position.y, inner_right_door.position.z);


        if (isIn) {
            liftOnTimer += Time.deltaTime;
            if (liftOnTimer > liftOnDelay) {
                transform.Translate(Vector3.up * Time.deltaTime);
                audio.Play();
                winTimer += Time.deltaTime;
                if(winTimer > 5f)
                {
                    SceneManager.LoadScene(0);
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player) {
            isIn = true;
        
        }
    }


}
