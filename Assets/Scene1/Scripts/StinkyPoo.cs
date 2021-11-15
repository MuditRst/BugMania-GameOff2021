using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StinkyPoo : MonoBehaviour
{
    GameObject player;

    float cooldown = 5f;

    public float health = 5f;
    
    [SerializeField]
    bool canMove,collided,bombPlanted;

    private Vector3 startingPosition;

    public GameObject stinkyPoo;

    void Start()
    {
        startingPosition = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    

    void Update()
    {
        if(cooldown <= 0 && bombPlanted){
            cooldown = 10f;
        }

        if(collided){
            StartCoroutine(BombCoolDown());
        }

        if(collided && Vector2.Distance(player.transform.position, this.transform.position) <= 3f){
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 5f*Time.deltaTime);
        }else{
            this.transform.position = Vector2.MoveTowards(this.transform.position, startingPosition, 5f*Time.deltaTime);
        }
        

    }

    IEnumerator BombCoolDown()
    {
        if(cooldown <= 0){
            yield return new WaitForSeconds(cooldown);
            Instantiate(stinkyPoo, player.transform.position, Quaternion.identity);
            bombPlanted = true;
        }else{
            cooldown -= Time.deltaTime;
            bombPlanted = false;
        }

        //Debug.Log(cooldown);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collided = true;
        }
    }


    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(25f);
            Destroy(this.gameObject);
        }
    }

    public void StinkyBugTakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }

}