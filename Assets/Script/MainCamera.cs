using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Transform player;
    private Vector3 offset;
    public float moveSpeed = 3;

    public float rotationSpeed = 3;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offset = transform.position - player.position;
        offset = new Vector3(0, offset.y, offset.z);
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 beginPos = player.position + offset;
        Vector3 endPos = player.position + offset.magnitude * Vector3.up;
        Vector3 pos1 = Vector3.Lerp(beginPos, endPos, 0.25f);
        Vector3 pos2 = Vector3.Lerp(beginPos, endPos, 0.5f);
        Vector3 pos3 = Vector3.Lerp(beginPos, endPos, 0.75f);
        Vector3[] posArray ={ beginPos, pos1, pos2, pos3, endPos };

        Vector3 targetPos = posArray[0];

        for(int i = 0; i < posArray.Length; i++) {
  
            RaycastHit hit;

            if (Physics.Raycast(posArray[i], player.position - posArray[i], out hit))
            {
                if (hit.collider.tag == Tags.player)
                {
                    targetPos = posArray[i];
                    break;
                }
                else
                {

                    continue;

                }
            }
        }

        //transform.position = targetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
        Quaternion curRotation = transform.rotation;
        transform.LookAt(player.position);
        //啥意思？
        transform.rotation = Quaternion.Lerp(curRotation, transform.rotation, rotationSpeed * Time.deltaTime);
    }
}
