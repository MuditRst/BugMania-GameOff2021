using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public GameObject broken;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(broken, this.transform.position, Quaternion.identity);
            Destroy(gameObject,0.5f);
        }
    }
}
