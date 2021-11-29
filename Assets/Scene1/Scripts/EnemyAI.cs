using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;


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
    [SerializeField] private AudioSource bug_walking;

    public AIPath aiPath;
    public bool stunned;

    Vector2 dir;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        aiPath.canMove = true;
    }

    void Update()
    {
       look();
    }
    
    void FixedUpdate(){
        if(aiPath.velocity.x > 0.1f){
            if(bug_walking.isPlaying == false){
                bug_walking.Play();
            }
        }

        if(stunned){
            aiPath.canMove = false;
            bug_walking.Stop();
            StartCoroutine(stunnedCoolDown());
        }

        if(timer <= 10 && isIdle == false && Vector2.Distance(transform.position, target.transform.position) < 12f && aiPath.canMove){
            StartCoroutine(CoolDown());
            aiPath.canMove = true;
            aiPath.maxSpeed = speed;
        }else{
            Stop();
            aiPath.canMove = false;
            bug_walking.Stop();
            if(idleTimer > 5 && isIdle == true){
               timer = 0;
               isIdle = false;
               idleTimer = 0;
               aiPath.canMove = true;
            }
            //Debug.Log("Idle Timer: "+  idleTimer);
        }

        //Debug.Log(timer);
    }


    /*public void move(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
    }*/

    public void Stop(){
        StartCoroutine(Idle());
        rb.velocity = Vector2.zero;
        /*if(Vector2.Distance(target.transform.position, transform.position) < 5f){
            GetComponentInChildren<EnemyAttack>().SpawnHerd();
        }*/
    }


    void look(){
        dir = aiPath.desiredVelocity;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f);
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

    IEnumerator stunnedCoolDown(){
        yield return new WaitForSeconds(3f);
        aiPath.canMove = true;
        stunned = false;
    }

}