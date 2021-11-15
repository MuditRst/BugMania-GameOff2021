using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{

    PatrolAi patrol;
    float speed = 4f;

    protected float timer=0f;

    protected float idleTimer = 0f;

    private Rigidbody2D rb;

    protected Vector2 movement;

    protected GameObject target;

    protected bool isIdle = false;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        targetDir.Normalize();
        movement = targetDir;
        if(Vector2.Distance(transform.position, target.transform.position) > 5f){
            GetComponent<PatrolAi>().enabled = true;
        }
    }
    
    void FixedUpdate(){

        if(timer <= 10 && isIdle == false && Vector2.Distance(transform.position, target.transform.position) < 7f){
            move(movement);
        }else{
            Stop();
            if(idleTimer > 5 && isIdle == true){
               timer = 0;
               isIdle = false;
               idleTimer = 0;
            }
            Debug.Log("Idle Timer: "+  idleTimer);
        }

        Debug.Log(timer);
    }


    public void move(Vector2 direction){
        StartCoroutine(CoolDown());
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
    }

    public void Stop(){
        StartCoroutine(Idle());
        rb.velocity = Vector2.zero;
        /*if(Vector2.Distance(target.transform.position, transform.position) < 5f){
            GetComponentInChildren<EnemyAttack>().SpawnHerd();
        }*/
    }

    IEnumerator CoolDown()
    {
        timer += Time.deltaTime;
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator Idle()
    {
        isIdle = true;
        idleTimer += Time.deltaTime;; 
        yield return new WaitForSeconds(3f);
        
    }

}