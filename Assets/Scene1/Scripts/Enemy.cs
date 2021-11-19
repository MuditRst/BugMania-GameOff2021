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

    void Update()
    {
        healthBar.setHealth(health,maxHealth);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        Debug.Log("Enemy Health: " + health);
    }


    void Die()
    {
        Destroy(gameObject);
    }

}