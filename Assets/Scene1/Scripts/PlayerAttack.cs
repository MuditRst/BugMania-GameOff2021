using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour{
    GameObject enemy;

    [SerializeField]
    bool CanAttack;

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "StinkyPoo" || other.gameObject.tag == "DebuffBug"){
            enemy = other.gameObject;
            CanAttack = true;
        }
    }

    void Update(){
        if(Input.GetButton("Fire1") && CanAttack){
            Attack(enemy);   
        }
    }

    void Attack(GameObject other){
        if(other.gameObject.tag == "StinkyPoo" && Vector2.Distance(transform.position, other.transform.position) <= 1f){
            other.GetComponent<StinkyPoo>().StinkyBugTakeDamage(2.5f);
        }
        if(other.gameObject.tag == "DebuffBug" && Vector2.Distance(transform.position, other.transform.position) <= 1f){
            other.GetComponent<Debuff>().DebuffBugTakeDamage(1f);
        }
        other.GetComponent<Enemy>().TakeDamage(1f);
    }
}