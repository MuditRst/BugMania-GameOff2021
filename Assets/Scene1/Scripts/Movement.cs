using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public Transform spawnPoint;

    [SerializeField] public bool isdashing;
    [SerializeField] public bool ischarging;

    public Sprite DashSprite;

    public Sprite AoeSprite;


    public float speed = 5f;
    public Rigidbody2D rb;
    public Sprite[] sprite;
    //public Animator anim;
    Vector2 movement;

    private Sprite originalsprite;

    [SerializeField]
    private bool isAoe;

    public SpriteRenderer UIicons;


    void Start()
    {
        //Timer.instance.BeginTimer();
        isAoe = true;
        originalsprite = GetComponent<SpriteRenderer>().sprite;
        UIicons = UIicons.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if(Input.GetButton("shift") && Input.GetButton("1")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[0];
            UIicons.sprite = AoeSprite;
        }

        if(Input.GetButton("shift") && Input.GetButton("2")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[1];
            UIicons.sprite = DashSprite;
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

        if(isAoe){
            Color temp = UIicons.color;
            temp.a += 1f;
            UIicons.color = temp;
            //Debug.Log(UIicons.color);
        }else{
            Color tmp = UIicons.color;
            tmp.a = 0.5f;
            UIicons.color = tmp;
            //Debug.Log(UIicons.color);
        }
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
                Debug.Log("AOE SLICE");
                AoeDamage();
            }
            //Debug.Log("Mantits");
        }

        //beetle

        if(bugsprite == "3"){
            /* speed = 12f */
            speed = 12f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x,0):new Vector2(0,movement.y)) * (speed) * Time.fixedDeltaTime);
            //Debug.Log("Bottle");
        }

        //grasshopper

        if(bugsprite == "4"){
            speed = 15f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x-5f,0):new Vector2(0,movement.y-5f)) * (speed) * Time.fixedDeltaTime);
            ChargeDamage();
            //Debug.Log("asshopper");
        }

    }

    private void ChargeDamage(){
        //Debug.Log("Charging");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1f);
        

        foreach(Collider2D enemy in hitEnemies){
            if(enemy.tag == "Enemy" && enemy.GetComponent<Enemy>().cantakeChargeDamage){
                enemy.GetComponent<Enemy>().TakeDamage(0.1f);
                enemy.GetComponent<Enemy>().transform.position = new Vector2(enemy.GetComponent<Enemy>().transform.position.x - 0.5f, enemy.GetComponent<Enemy>().transform.position.y - 0.1f);
                enemy.GetComponent<EnemyAI>().stunned = true;
                enemy.GetComponent<Enemy>().cantakeChargeDamage = false;
            }
        }
    }

    private void AoeDamage(){
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        foreach(Collider2D c in collider2D){
            if(c.tag == "Enemy" && c.GetComponent<Enemy>().cantakeAoeDamage){
                c.GetComponent<Enemy>().TakeDamage(10f);
                c.GetComponent<Enemy>().cantakeAoeDamage  = false;
            }
        }
        StartCoroutine(AoeSlice());
    }


    IEnumerator DashCooldown(){
        isdashing = true;
        yield return new WaitForSeconds(0.1f);
        speed = 5f;
        isdashing = false;
    }

    IEnumerator ChargeCooldown(){
        ischarging = true;
        yield return new WaitForSeconds(3f);
        speed = 5f;
        ischarging = false;
    }


    IEnumerator AoeSlice(){
        isAoe = false;
        yield return new WaitForSeconds(10f);
        isAoe = true;
    }


}


/* Rush
this.transform.position = new Vector2(Input.GetAxisRaw("Horizontal") > 0?this.transform.position.x+0.09f:this.transform.position.x-0.09f,0f);
 */