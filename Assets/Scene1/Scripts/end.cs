using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public TMP_Text text;
    [SerializeField] private GameObject ObjectPrefab;
    private string ObjectID;
    

    void Start(){
        ObjectID = ObjectPrefab.GetComponent<CollectibleID>().ID;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();
        }
        text.text = "Thank You for playing our game!\n\n" + "Assence Collected: " + PlayerPrefs.GetInt(ObjectID).ToString() + "\n" + "Your Time: " + Timer.instance.timerText.text;
    }
}

