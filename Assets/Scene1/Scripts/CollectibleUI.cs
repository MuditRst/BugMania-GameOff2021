using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleUI : MonoBehaviour
{
    [SerializeField] private GameObject ObjectPrefab;
    private Text text;

    private string ObjectID;

    void Awake()
    {
        text = GetComponent<Text>();
        ObjectID = ObjectPrefab.GetComponent<CollectibleID>().ID;
    }


    void LateUpdate()
    {
        text.text = "Orbs Collected:" + PlayerPrefs.GetInt(ObjectID).ToString();
    }




}
