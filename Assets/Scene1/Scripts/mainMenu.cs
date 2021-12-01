using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{

    [SerializeField] private GameObject ObjectPrefab;

    public AudioSource audioSource;
    private string ObjectID;


    void Start(){
        ObjectID = ObjectPrefab.GetComponent<CollectibleID>().ID;
    }
    public void play(){
        audioSource.Play();
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(ObjectID, 0);
        PlayerPrefs.SetFloat("Health",100f);
        SceneManager.LoadScene(1);
    }

    public void quit(){
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
