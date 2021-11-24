using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{

    int sceneIndex;
    public Image image;

    void Start(){
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            image.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}