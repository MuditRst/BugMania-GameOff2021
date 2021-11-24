using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text text;
    [SerializeField] private GameObject objectPrefab;
    private string ObjectID;

    public Image image;

    void Start(){
        ObjectID = objectPrefab.GetComponent<CollectibleID>().ID;
        image.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void Update(){
        text.text = "GameOver!" + "\n" + "Orbs Collected: " + PlayerPrefs.GetInt(ObjectID).ToString() + "\n" + "Time Played: " + Timer.instance.timerText.text;
    }

}
