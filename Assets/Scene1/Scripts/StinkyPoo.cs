using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StinkyPoo : MonoBehaviour
{
    GameObject player;

    float maxHealth = 20f;

    public GameObject bombIndicator;

    public HealthBar stinkyPooHealthBar;

    public GameObject stinkyPooCorpse;

    float cooldown = 5f;

    [SerializeField]
    int bombShown=0;
 

    float health = 20f;
    
    [SerializeField]
    bool canMove,collided,bombPlanted;

    public AudioSource bombSound;

    private Vector3 startingPosition;

    public GameObject stinkyPoo;

    Vector2 bPos;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startingPosition = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    

    void Update()
    {
        stinkyPooHealthBar.setHealth(health,maxHealth);
        if(GameObject.FindGameObjectWithTag("BombIndicator")){
            Destroy(GameObject.FindGameObjectWithTag("BombIndicator"),0.5f);
        }

        if(GameObject.FindGameObjectWithTag("BombIndicator")){
            bPos = GameObject.FindGameObjectWithTag("BombIndicator").transform.position;
        }

        if(Vector2.Distance(player.transform.position,this.transform.position) >= GetComponent<CircleCollider2D>().radius/2){
            collided = false;
        }


        if(cooldown <= 0 && bombPlanted){
            cooldown = 5f;
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
            Instantiate(stinkyPoo, bPos, Quaternion.identity);
            bombPlanted = true;
            bombShown = 0;
        }else{
            cooldown -= Time.deltaTime;
            bombPlanted = false;
        }


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
            
            if(col.gameObject.GetComponent<Movement>().isdashing == false && col.gameObject.GetComponent<Movement>().ischarging == false){
                PlayerPrefs.SetFloat("Health",PlayerPrefs.GetFloat("Health") - 25f);
                col.gameObject.GetComponent<PlayerHealth>().particle.Play();
                col.gameObject.GetComponent<PlayerHealth>().particle.transform.position = col.gameObject.transform.position;
                col.gameObject.GetComponent<PlayerHealth>().shake.CamShake();
            }
            Instantiate(stinkyPooCorpse, transform.position, transform.rotation);
            StartCoroutine(playDeathAudio());
        }
    }

    IEnumerator playDeathAudio(){
    
        audioSource.Play();
        
        while (audioSource.isPlaying){
            this.transform.position = new Vector3(this.transform.position.x-99f, this.transform.position.y-90f, this.transform.position.z - 99f);
            yield return null;
        }
        
        Destroy(this.gameObject);
    }

    public void StinkyBugTakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Instantiate(stinkyPooCorpse, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

}