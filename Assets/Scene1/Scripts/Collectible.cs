using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private CollectibleID collectibleID;
    AudioSource audioSource;


    void Awake()
    {
        collectibleID = GetComponent<CollectibleID>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(collectibleID.ID,PlayerPrefs.GetInt(collectibleID.ID) + 1);
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length/2 - 0.32f);   
        }
    }
}
