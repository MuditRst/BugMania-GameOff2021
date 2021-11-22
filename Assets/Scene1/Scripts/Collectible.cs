using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private CollectibleID collectibleID;


    void Awake()
    {
        collectibleID = GetComponent<CollectibleID>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(collectibleID.ID,PlayerPrefs.GetInt(collectibleID.ID) + 1);
            Destroy(gameObject);
        }
    }
}
