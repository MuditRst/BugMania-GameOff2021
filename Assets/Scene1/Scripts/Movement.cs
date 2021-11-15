using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public Transform spawnPoint;
    public float speed = 5f;
    public Rigidbody2D rb;
    public Sprite[] sprite;
    //public Animator anim;
    Vector2 movement;

    private Sprite originalsprite;

    private bool isAoe;



    void Start()
    {
        originalsprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {

        if(Input.GetButton("shift") && Input.GetButton("1")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[0];
        }

        if(Input.GetButton("shift") && Input.GetButton("2")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[1];
        }

        if(Input.GetButton("shift") && Input.GetButton("3")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[2];
        }

        if(Input.GetButton("shift") && Input.GetButton("0")){
            this.GetComponent<SpriteRenderer>().sprite = originalsprite;
        }

        if(Input.GetButton("SpecialKey")){
            bugs(this.GetComponent<SpriteRenderer>().sprite.name);
            StartCoroutine(DashCooldown());
            if(Input.GetButtonDown("SpecialKey")){
                bugs(this.GetComponent<SpriteRenderer>().sprite.name);
                StartCoroutine(ChargeCooldown());
            }
            
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        look();
        
        //anim.SetFloat("horizontal",movement.x);
        //anim.SetFloat("vertical",movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    
    void OnCollisionEnter2D(Collision2D col){
        
    }


    void look(){
        Vector3 lookPos = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position);
        rb.rotation = (Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg) - 90f;
    }

    void bugs(string bugsprite){


        //mantice

        if(bugsprite == "1"){
            //AOE SLICE;
            if(isAoe){



                StartCoroutine(AoeSlice());
            }
            //Debug.Log("Mantits");
        }

        //beetle

        if(bugsprite == "3"){
            /* speed = 12f */
            speed = 15f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x,0):new Vector2(0,movement.y)) * (speed) * Time.fixedDeltaTime);
            //Debug.Log("Bottle");
        }

        //grasshopper

        if(bugsprite == "4"){
            speed = 15f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x-5f,0):new Vector2(0,movement.y-5f)) * (speed) * Time.fixedDeltaTime);
            //Debug.Log("asshopper");
        }

    }

    IEnumerator DashCooldown(){
        yield return new WaitForSeconds(0.1f);
        speed = 5f;
    }

    IEnumerator ChargeCooldown(){
        yield return new WaitForSeconds(3f);
        speed = 5f;
    }


    IEnumerator AoeSlice(){
        yield return new WaitForSeconds(30f);
        isAoe = true;
    }

}


/* Rush
this.transform.position = new Vector2(Input.GetAxisRaw("Horizontal") > 0?this.transform.position.x+0.09f:this.transform.position.x-0.09f,0f);
 */