using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAttack : EnemyAI
{
    public float timeBetweenAttacks = 7f;
    public float attackDamage = 1f;

    public GameObject EnemyHerd;

    public int HerdCount;

    GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Attack()
    {
        StartCoroutine(AttackWait());
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        StartCoroutine(Idle());
        Stop();
        if(idleTimer > 5f && isIdle == true){
            timer = 0;
            isIdle = false;
            idleTimer = 0;
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
        yield return new WaitForSeconds(timeBetweenAttacks + Time.deltaTime);
    }

    /*public IEnumerator destroyHerd(){
        yield return new WaitForSeconds(5f);
        Destroy(EnemyHerd);
        Debug.Log("Destroyed Herd");
    }*/

}