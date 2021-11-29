using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    Animator anim;
    bool collided;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        if(collided == false){
            Destroy(gameObject, audioSource.clip.length/2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            collided = true;
            anim.SetBool("isExplosion", true);
            //other.gameObject.GetComponent<PlayerHealth>().TakeDamage(10f);
            PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - 10f);
            other.gameObject.GetComponent<PlayerHealth>().particle.Play();
            other.gameObject.GetComponent<PlayerHealth>().shake.CamShake();
            anim.SetBool("isExplode", false);
            Destroy(gameObject,audioSource.clip.length - 0.2f);
        }
    }
}
