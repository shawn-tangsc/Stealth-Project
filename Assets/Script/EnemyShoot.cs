using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float minDamage = 35;
    private Animator anim;
    private GameObject player;
    private PlayerHealth health;
    private bool isShoot = false;
    private AudioSource shootAuido;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        health = player.GetComponent<PlayerHealth>();
        shootAuido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetFloat("Shot") > 0.5f)
        {
            if (!isShoot) {
                isShoot = true;
                Shooting();
                
            }
        }
   
    }


    private void Shooting() {
      
        float damage = minDamage + 100 - 7 * (player.transform.position - transform.position).magnitude;
        print(damage);
        health.TakeDamage(damage);
        isShoot = false;
        shootAuido.Play();
    }
}
