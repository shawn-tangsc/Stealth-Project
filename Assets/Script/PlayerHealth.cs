using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float HP = 100;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(float damage) {


        if (HP > 0) {
            HP -= damage;
        }
        else
        {
            anim.SetBool("isDeath", true);
            anim.StopRecording();
            StartCoroutine(ReloadScene());
        }




    }

    IEnumerator ReloadScene() {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    
    }
}
