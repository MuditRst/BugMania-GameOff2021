using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Debuff : MonoBehaviour
{
    [SerializeField]
    bool isInRange = false;
    GameObject player;

    public GameObject DebuffCorpse;

    public HealthBar healthBar;

    float DBhealth = 5f;
    float DBmaxHealth = 5f;

    public AudioSource audioSource;


    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.setHealth(DBhealth,DBmaxHealth);
        audioSource.Play();
    }

    void Update(){
        healthBar.setHealth(DBhealth,DBmaxHealth);
        if(isInRange && player.GetComponent<Movement>().speed >= 2f)
            player.GetComponent<Movement>().speed -= 0.001f;

        if(Vector2.Distance(transform.position, player.transform.position) > 8f && player.GetComponent<Movement>().speed < 5.1f){
            player.GetComponent<Movement>().speed += 0.01f;
        }

    }

    public void DebuffBugTakeDamage(float damage){
        Debug.Log("Hit!");
        DBhealth -= damage;
        if(DBhealth <= 0){
            Instantiate(DebuffCorpse, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            isInRange = true;
        }
    }

}