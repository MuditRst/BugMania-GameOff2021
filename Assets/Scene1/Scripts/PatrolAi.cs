using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAi : EnemyAI
{
    GameObject player;

    protected float maxX = 8.78f;
    protected float minX = -8.78f;

    protected float maxY = 3.56f;
    protected float minY = -3.56f;
    public float speed = 5f;
    private float startwaittime = 4.5f;
    private float waittime;

    public Transform movespot;

    private Vector2 dir;

    public LayerMask mask;
    
    void Start()
    {
        waittime = startwaittime;
        player = GameObject.FindGameObjectWithTag("Player");
        movespot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    
    void Update()
    {
        Vector3 targetDir = transform.position - movespot.position;
        targetDir.Normalize();
        dir = targetDir;

        if(Vector2.Distance(transform.position,player.transform.position) < 5f)
        {
            enabled = false;
            //isIdle = false;
        }

        if(Vector2.Distance(GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position,GameObject.FindGameObjectsWithTag("Enemy")[1].transform.position) <= 1f){
            movespot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
        

        patrol(dir);
    }


    private void patrol(Vector2 direction)
    {
        //this.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg-90f;
        transform.position = Vector2.MoveTowards(transform.position, movespot.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, movespot.position) < 0.2f)
        {
            if(waittime <= 0)
            {
                movespot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waittime = startwaittime;
            }else{
                waittime -= Time.deltaTime;
            }
        }
    }
}
