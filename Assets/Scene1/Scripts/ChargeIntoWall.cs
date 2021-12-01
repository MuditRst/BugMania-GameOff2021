using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeIntoWall : MonoBehaviour
{
    [SerializeField] private bool collided;
    [SerializeField] private GameObject player;

    public Animator anim;


    void Start(){
        collided = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (collided && player.GetComponent<Movement>().speed > 10f && player.GetComponent<SpriteRenderer>().sprite.name == "BottleTheBeetle_0")
        {
            collided = false;
            anim.SetTrigger("shake");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collided = true;
        }
    }
}
