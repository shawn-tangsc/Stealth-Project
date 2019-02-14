using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCard : MonoBehaviour {
    public AudioClip pickUpKeyCardSource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player) {
            Player player = other.GetComponent<Player>();
            player.hasKey = true;
            // 这种方法播放声音会导致声音刚刚开始播放，游戏物体就被销毁了，所以不适合此场景
            //if (!pickUpKeyCardSource.isPlaying) {
            //    pickUpKeyCardSource.Play();
            //}

            AudioSource.PlayClipAtPoint(pickUpKeyCardSource, transform.position,10f);
            Destroy(this.gameObject);
        }
    }
}
