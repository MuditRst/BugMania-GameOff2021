using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{
    
  public Slider slider;
  public Vector3 offset;


    public void setHealth(float health,float maxHealth){
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.gameObject.SetActive(health < maxHealth);

    }

    void Update(){
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        if(GameObject.FindGameObjectWithTag("Player") == null){
            slider.value = 0;
        }
    }



}


