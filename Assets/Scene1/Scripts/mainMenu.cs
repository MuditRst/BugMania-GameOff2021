using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{

    public AudioSource audioSource;
    public void play(){
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Health",100f);
        SceneManager.LoadScene(1);
    }

    public void quit(){
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
