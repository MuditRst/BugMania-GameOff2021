using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                SceneManager.LoadScene("Test-Level#2");
        }
    }
}
