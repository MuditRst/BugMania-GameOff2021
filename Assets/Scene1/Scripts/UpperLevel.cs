using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperLevel : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private bool collided;
    [SerializeField] private bool isUpperLevel;

    public GameObject groundLevel;
    public GameObject upperLevel;

    void Start()
    {
        collided = false;
        upperLevel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (collided)
        {
            if(!isUpperLevel && Input.GetKeyDown(KeyCode.Q) && player.GetComponent<SpriteRenderer>().sprite.name == "2" && Vector2.Distance(player.transform.position, transform.position) < 0.25f){
                groundLevel.SetActive(false);
                upperLevel.SetActive(true);
                isUpperLevel = true;
                collided = false;
                GameObject[] objs = GameObject.FindGameObjectsWithTag("corpse");
                foreach (GameObject obj in objs)
                {
                Destroy(obj);
                }
            }else if(isUpperLevel && player.GetComponent<SpriteRenderer>().sprite.name == "2" && Vector2.Distance(player.transform.position, transform.position) < 0.25f){
                if(Input.GetKeyDown(KeyCode.Q)){
                    groundLevel.SetActive(true);
                    upperLevel.SetActive(false);
                    isUpperLevel = false;
                    collided = false;
                }
            }
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            collided = true;
        }
    }
}
