using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    float heatlh = 200f;
    float speed = 3.5f;
    float attack = 10f;

    [SerializeField]
    bool ragePhase = false;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveCoolDown());
    }


    void Update()
    {

        int n = randomGen();

        switch(n){
            case 1:
                if(Vector2.Distance(transform.position, player.transform.position) > 1f){
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
                }else{
                    //player.GetComponent<PlayerHealth>().TakeDamage(attack);
                }
                Debug.Log("Hit Player");
                StartCoroutine(MoveCoolDown());
                break;
            case 2:
                if(Vector2.Distance(transform.position, player.transform.position) >= 5f){
                    if(!ragePhase){
                        speed = 5f;
                    }else{
                        speed = 8.5f;
                    }

                    
                    Transform targetPos = player.transform;

                    transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed*Time.deltaTime);
                }
                
                /*
                    Instantiate(projectile, transform.position, Quaternion.identity);
                */
                Debug.Log("Charge At Player");
                StartCoroutine(MoveCoolDown());
                break;
            case 3:
                //shoot player
                Debug.Log("Shoot Player");
                StartCoroutine(MoveCoolDown());
                break;

        }



        if(heatlh <= 0)
        {
            Destroy(gameObject);
        }
        
        if(heatlh < 125f){
            /*

            change state

            Rage Mode?

            -Buffed Stats
            -Lower Damage Taken
            -Higher Damage Output
            -more speed



            */

            ragePhase = true;
            speed = 7f;
            attack = 25f;
        }


        
    }



    int randomGen(){
        return Mathf.Abs(Random.Range(1,4));
    }

    IEnumerator MoveCoolDown(){
        yield return new WaitForSeconds(10f);
    }


}
