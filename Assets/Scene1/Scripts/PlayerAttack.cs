using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour{
    GameObject enemy;

    [SerializeField]
    bool CanAttack;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
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
        Debug.Log("Attacking!");
        if(other.gameObject.tag == "StinkyPoo"){
            other.GetComponent<StinkyPoo>().StinkyBugTakeDamage(1f);
        }
        other.GetComponent<Enemy>().TakeDamage(1f);
        
    }
}