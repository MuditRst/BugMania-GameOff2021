using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("Health",PlayerPrefs.GetFloat("Health")+10f);
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length/2 - 0.25f);
        }
    }
}
