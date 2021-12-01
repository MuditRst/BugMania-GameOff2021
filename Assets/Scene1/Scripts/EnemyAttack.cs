using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAttack : EnemyAI
{
    public float timeBetweenAttacks = 7f;
    public float attackDamage = 10f;

    public GameObject EnemyHerd;

    public int HerdCount;

    GameObject player;
    public Animator anim;

    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Attack()
    {
        StartCoroutine(AttackWait());
        if(!player.GetComponent<Movement>().isdashing && !player.GetComponent<Movement>().ischarging){
            PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - attackDamage);
            player.GetComponent<PlayerHealth>().particle.Play();
            player.GetComponent<PlayerHealth>().shake.CamShake();
        }


        StartCoroutine(Idle());
        Stop();
        aiPath.canMove = false;
        if(idleTimer > 5f && isIdle == true){
            timer = 0;
            isIdle = false;
            idleTimer = 0;
            aiPath.canMove = true;
        }
    }   


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Attack();
            Debug.Log("Attacking!");
        }
    }

    public void SpawnHerd(){
        if(HerdCount < 2){
            Instantiate(EnemyHerd, this.transform.position, transform.rotation);
            HerdCount++;
        }

    }

    IEnumerator AttackWait(){
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(timeBetweenAttacks + Time.deltaTime);
        anim.SetBool("Attack", false);
    }

}