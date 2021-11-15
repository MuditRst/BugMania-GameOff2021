using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAi : EnemyAI
{
    GameObject player;

    float maxX = 8.78f;
    float minX = -8.78f;

    float maxY = 3.56f;
    float minY = -3.56f;
    public float speed = 5f;
    private float startwaittime = 4.5f;
    private float waittime;

    public Transform movespot;

    private Vector2 dir;
    
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
