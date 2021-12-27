using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{

    void Start(){
        this.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void Update(){
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            this.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                SceneManager.LoadScene("Test-Level#2");
        }
    }
}
