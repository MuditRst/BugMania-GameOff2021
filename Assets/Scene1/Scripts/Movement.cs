using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] public bool isdashing;
    [SerializeField] public bool ischarging;

    public bool gotBeetle,gotMantis;
    public Sprite DashSprite;

    public Sprite AoeSprite;
    public Animator animator;


    public float speed = 5f;
    public Rigidbody2D rb;
    public Sprite[] sprite;
    Vector2 movement;

    [SerializeField] private Sprite originalsprite;

    [SerializeField]
    private bool isAoe;

    public SpriteRenderer UIicons;

    public GameObject dash;

    public Transform dashTransform;

    public AudioSource dashSound;


    void Start()
    {
        PlayerPrefs.SetString("Scene",SceneManager.GetActiveScene().name);
        
        isAoe = true;
        originalsprite = GetComponent<SpriteRenderer>().sprite;
        UIicons = UIicons.GetComponent<SpriteRenderer>();
        UIicons.sprite = DashSprite;
    }

    void Update()
    {
        if(Input.GetButton("shift") && Input.GetButton("0")){
            animator.SetBool("isBeetle", false);
            this.GetComponent<SpriteRenderer>().sprite = originalsprite;
        }

        if(Input.GetButton("shift") && Input.GetButton("1") && PlayerPrefs.GetInt("Mantis") == 1){
            this.GetComponent<SpriteRenderer>().sprite = sprite[0];
            UIicons.sprite = AoeSprite;
        }

        if(Input.GetButton("shift") && Input.GetButton("2")){
            this.GetComponent<SpriteRenderer>().sprite = sprite[1];
            UIicons.sprite = DashSprite;
        }

        if(Input.GetButton("shift") && Input.GetButton("3") &&  PlayerPrefs.GetInt("Beetle") == 1){
            this.GetComponent<SpriteRenderer>().sprite = sprite[2];
            animator.SetBool("isBeetle",true);
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

        

        if(Input.GetKey(KeyCode.Q) && GetComponent<SpriteRenderer>().sprite.name == "GaryTheGrasshopper_22"){
            StartCoroutine(DashAnimation());    
        }else{
            animator.SetBool("Dash",false);
        }

        

        if(Input.GetKey(KeyCode.Q) && GetComponent<SpriteRenderer>().sprite.name == "BottleTheBeetle_0")
            StartCoroutine(ChargeAnimation());
        else
            animator.SetBool("Charge",false);

        GameObject[] g = GameObject.FindGameObjectsWithTag("dash");

        foreach(GameObject d in g)
            Destroy(d,0.05f);

        if(isdashing){
            Instantiate(dash,dashTransform.position,Quaternion.identity);
            dashSound.Play();
        }

        if(ischarging){
            dashSound.Play();
        }

        

        if(isAoe){
            Color temp = UIicons.color;
            temp.a += 1f;
            UIicons.color = temp;
            
        }else{
            Color tmp = UIicons.color;
            tmp.a = 0.5f;
            UIicons.color = tmp;
            
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


        //mantis

        if(bugsprite == "1"){
            if(isAoe){
                Debug.Log("AOE SLICE");
                AoeDamage();
            }
            
        }

        

        if(bugsprite == "BottleTheBeetle_0"){
            
            speed = 12f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x,0):new Vector2(0,movement.y)) * (speed) * Time.fixedDeltaTime);
            ChargeDamage();
        
        }

        

        if(bugsprite == "GaryTheGrasshopper_22"){
            speed = 15f;
            rb.MovePosition(rb.position + (Input.GetAxisRaw("Horizontal") > 0?new Vector2(movement.x-5f,0):new Vector2(0,movement.y-5f)) * (speed) * Time.fixedDeltaTime);
        }

    }

    private void ChargeDamage(){
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

    IEnumerator ChargeAnimation(){
        animator.SetBool("Charge",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    IEnumerator DashAnimation(){
        animator.SetBool("Dash",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

}