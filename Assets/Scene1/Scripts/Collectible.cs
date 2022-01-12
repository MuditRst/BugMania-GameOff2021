using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private CollectibleID collectibleID;
    
    public AudioClip audioClip;
    

    void Start()
    {
        collectibleID = GetComponent<CollectibleID>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(collectibleID.ID,PlayerPrefs.GetInt(collectibleID.ID) + 1);
            AudioSource.PlayClipAtPoint(audioClip, this.transform.position);
            Destroy(this.gameObject);   
        }
    }
}
