using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUnit : MonoBehaviour {
    public GameObject laser;
    private bool isUnlock = false;
    private AudioSource switchSource;
    public Material unlockMet;
    public GameObject screen;
	// Use this for initialization
	void Start () {
        switchSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isUnlock) {

            //if (laser.localScale.z > 0.1)
            //{
            //    float z = Mathf.Lerp(laser.position.z, 0, Time.deltaTime);

            //    laser.localScale = new Vector3(laser.position.x, laser.position.y, z);

            //}

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.player)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isUnlock = true;
                if (!switchSource.isPlaying) {
                    switchSource.Play();
                }
                
                laser.SetActive(false);

                MeshRenderer renderer =  screen.GetComponent<MeshRenderer>();
                renderer.material = unlockMet;

            }
        }

    }
    
}
