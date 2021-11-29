using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth:MonoBehaviour{

    static float health = 100f;

    public GameObject GameOverMenu;

    public Slider slider;
    public shake shake;

    public ParticleSystem particle;
    
    void Start(){
        slider.maxValue = health;
        particle = GetComponent<ParticleSystem>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<GameAudio>().PlayMusic();
    }
    void Update(){
        slider.value = PlayerPrefs.GetFloat("Health");

        if (PlayerPrefs.GetFloat("Health") <= 0f)
        {
            Die();
        }
    }


    void Die(){
        slider.value = 0;
        Timer.instance.endTimer();
        GameOverMenu.GetComponent<Stats>().image.gameObject.SetActive(true);
        GameOverMenu.SetActive(true);
        Destroy(gameObject);
    }
}