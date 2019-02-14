using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController _instance;
    public bool alermOn = false;
    public Vector3 playerPosition;
    private GameObject[] alerms;

    public AudioSource musicNormal;

    public AudioSource musicPanic;

    public float musicWipperSpeed = 1;

    // Use this for initialization

    private void Awake()
    {
        alermOn = false;
        _instance = this;
    }
	// Update is called once per frame
	void Update () {
        AlermLight._instance.isAlerm = alermOn;
        alerms = GameObject.FindGameObjectsWithTag(Tags.alerm);
        if (alermOn) {
            startAlerm();

        }
        else {
            stopAlerm();


        }

    }

    private void startAlerm()
    {
        foreach (GameObject go in alerms)
        {
            var goAudio = go.GetComponent<AudioSource>();
            if (!goAudio.isPlaying) {
                goAudio.Play();
            }
        }
        musicPanic.enabled=true;
        musicNormal.enabled = false;

        musicPanic.volume = Mathf.Lerp(musicPanic.volume, 0.3f, Time.deltaTime * musicWipperSpeed);

        musicNormal.volume = Mathf.Lerp(musicNormal.volume, 0f, Time.deltaTime * musicWipperSpeed);

    }

    private void stopAlerm() {
        foreach (GameObject go in alerms)
        {
            var goAudio = go.GetComponent<AudioSource>();
            goAudio.Stop();
        }

    }


    public void SeePlayer(Transform player) {
        alermOn = true;
        playerPosition = player.position;
    }

        

}
