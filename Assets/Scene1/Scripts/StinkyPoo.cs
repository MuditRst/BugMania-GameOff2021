using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StinkyPoo : MonoBehaviour
{
    GameObject player;

    float maxHealth = 5f;

    public GameObject bombIndicator;

    public HealthBar stinkyPooHealthBar;

    float cooldown = 5f;

    [SerializeField]
    int bombShown=0;
 

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
        stinkyPooHealthBar.setHealth(health,maxHealth);
        if(GameObject.FindGameObjectWithTag("BombIndicator")){
            Destroy(GameObject.FindGameObjectWithTag("BombIndicator"),0.5f);
        }

        if(Vector2.Distance(player.transform.position,this.transform.position) >= GetComponent<CircleCollider2D>().radius/2){
            collided = false;
        }


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

        if(cooldown <= 0.35f && bombShown <= 1 && collided){
            Instantiate(bombIndicator,player.transform.position,Quaternion.identity);
            bombShown++;
        }

        if(cooldown <= 0 && collided){
            yield return new WaitForSeconds(cooldown);
            Instantiate(stinkyPoo, player.transform.position, Quaternion.identity);
            bombPlanted = true;
            bombShown = 0;
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