using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    float health = 25f;

    public bool cantakeAoeDamage = true;
    public bool cantakeChargeDamage = true;

    float maxHealth = 25f;

    public HealthBar healthBar;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    ParticleSystem particles;

    public GameObject corpse;

    public GameObject drop;


    void Start()
    {
        audioSource.clip = deathSound;
        particles = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        healthBar.setHealth(health,maxHealth);

        if(cantakeChargeDamage){
            StartCoroutine(cantakeChargeDamageCoolDown());
        }

        if(cantakeAoeDamage == false){
            StartCoroutine(cantakeAoeDamageCoolDown());
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
        Instantiate(corpse, transform.position, transform.rotation);
        if(RandomDDrop() >= 1){
            Instantiate(drop, transform.position, transform.rotation);
        }
        StartCoroutine(playDeathAudio());
    }

    IEnumerator playDeathAudio(){
    
        audioSource.Play();
        
        while (audioSource.isPlaying){
            this.transform.position = new Vector3(this.transform.position.x-99f, this.transform.position.y-90f, this.transform.position.z - 99f);
            yield return null;
        }
        
        Destroy(gameObject);
    }

    IEnumerator cantakeChargeDamageCoolDown(){
        yield return new WaitForSeconds(5f);
        cantakeChargeDamage = true;
    }

    IEnumerator cantakeAoeDamageCoolDown(){
        yield return new WaitForSeconds(20f);
        cantakeAoeDamage = true;
    }
}