using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth:MonoBehaviour{

    public float health = 100f;

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
        Destroy(gameObject);
    }




}