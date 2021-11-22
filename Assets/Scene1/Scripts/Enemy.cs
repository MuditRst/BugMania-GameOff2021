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


    ParticleSystem particles;

    public GameObject corpse;

    public GameObject drop;


    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        healthBar.setHealth(health,maxHealth);
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
        Destroy(gameObject);
    }

}