using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth:MonoBehaviour{

    public float health = 100f;

    public Slider slider;


    void Start(){
        slider.maxValue = health;
    }
    void Update(){
        slider.value = health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        Debug.Log("Player Health: " + health);
    }


    void Die(){
        health = 0f;
        Destroy(gameObject);

        SceneManager.LoadScene(4);
    }




}