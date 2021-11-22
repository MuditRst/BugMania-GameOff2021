using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 25f;

    float maxHealth = 25f;

    public HealthBar healthBar;

    AudioSource audioSrc;
    ParticleSystem particles;

    public GameObject corpse;

    public GameObject drop;


    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        audioSrc = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        healthBar.setHealth(health,maxHealth);

        if(audioSrc.clip == null)
        {
            Debug.Log("No Audio!!!");
        }
    }

    public void TakeDamage(float amount)
    {
        particles.Play();
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        //Debug.Log("Enemy Health: " + health);
    }


    int RandomDDrop(){
        return Mathf.Abs(Random.Range(0, 2 ));
    }

    void Die()
    {
        StartCoroutine(playAudio());
        Instantiate(corpse, transform.position, transform.rotation);
        if(RandomDDrop() >= 1){
            Instantiate(drop, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    IEnumerator playAudio(){
        audioSrc.Play();

        while(audioSrc.isPlaying){
            yield return null;
        }
    }

}