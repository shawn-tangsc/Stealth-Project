using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVCam : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Tags.player) {
            GameController._instance.alermOn = true;
            GameController._instance.playerPosition = other.transform.position;
        }
    }
}
