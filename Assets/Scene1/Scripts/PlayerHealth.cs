using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth:MonoBehaviour{

    public float health = 100f;

    public GameObject GameOverMenu;

    public Slider slider;
    private shake shake;

    ParticleSystem particle;


    void Start(){
        particle = GetComponent<ParticleSystem>();
        slider.maxValue = health;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }
    void Update(){
        slider.value = health;
    }
    public void TakeDamage(float amount)
    {
        particle.Play();
        health -= amount;
        shake.CamShake();
        if (health <= 0f)
        {
            Die();
        }

        Debug.Log("Player Health: " + health);
    }


    void Die(){
        slider.value = 0;
        Timer.instance.endTimer();
        GameOverMenu.GetComponent<Stats>().image.gameObject.SetActive(true);
        GameOverMenu.SetActive(true);
        Destroy(gameObject);
    }
}