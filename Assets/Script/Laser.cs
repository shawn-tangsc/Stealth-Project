using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public bool isFilcker = false;

    public float OnTime = 3;

    public float OffTime = 3;

    private float time = 0;

    private MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isFilcker) {
            time += Time.deltaTime;

            if (renderer.enabled)
            {
                if (time >= OnTime) {
                    time = 0;
                    renderer.enabled = false;
                   }

            }

            if (!renderer.enabled) {
                if (time >= OffTime)
                {
                    time = 0;
                    renderer.enabled = true;
                }
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Tags.player && renderer.enabled) {
            GameController._instance.alermOn = true;
            GameController._instance.playerPosition = other.transform.position;
        }
    }

}
