using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour{
    GameObject enemy;

    [SerializeField]
    bool CanAttack;

    public Animator animator;

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "StinkyPoo" || other.gameObject.tag == "DebuffBug"){
            enemy = other.gameObject;
            CanAttack = true;
        }
    }

    void Update(){
        if(Input.GetButton("Fire1") && CanAttack){
            Attack(enemy); 
            CanAttack = false;  
        }
        if(Input.GetButton("Fire1")){
            animator.SetBool("Attack", true);
        }else{
            animator.SetBool("Attack", false);
        }

        if(Input.GetButton("Fire1") && GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite.name == "BottleTheBeetle_0"){
            animator.SetBool("beetleAttack", true);
        }else{
            animator.SetBool("beetleAttack", false);
        }
    }

    void Attack(GameObject other){
        if(other.gameObject.tag == "StinkyPoo" && Vector2.Distance(transform.position, other.transform.position) <= 1f){
            other.GetComponent<StinkyPoo>().StinkyBugTakeDamage(10f);
        }
        if(other.gameObject.tag == "DebuffBug" && Vector2.Distance(transform.position, other.transform.position) <= 1f){
            other.GetComponent<Debuff>().DebuffBugTakeDamage(10f);
        }
        other.GetComponent<Enemy>().TakeDamage(10f);
    }
}