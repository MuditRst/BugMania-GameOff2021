using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Debuff : MonoBehaviour
{
    [SerializeField]
    bool isInRange = false;
    GameObject player;


    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if(isInRange && player.GetComponent<Movement>().speed >= 2f)
            player.GetComponent<Movement>().speed -= 0.001f;
        Debug.Log(player.GetComponent<Movement>().speed);

        if(Vector2.Distance(transform.position, player.transform.position) > 8f && player.GetComponent<Movement>().speed < 5.1f){
            player.GetComponent<Movement>().speed += 0.01f;
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            isInRange = true;
        }
    }

}