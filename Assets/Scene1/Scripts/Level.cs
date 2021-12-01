using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("StinkyPoo").Length == 0)
                SceneManager.LoadScene(this.gameObject.scene.buildIndex + 1);
        }
    }
}
