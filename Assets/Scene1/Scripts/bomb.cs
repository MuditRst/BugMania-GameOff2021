using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isExplosion", true);
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(10f);
            anim.SetBool("isExplode", false);
            Destroy(gameObject,0.5f);
        }
    }
}
