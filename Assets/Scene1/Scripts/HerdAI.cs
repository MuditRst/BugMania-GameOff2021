using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HerdAI : EnemyAI
{

    float herdHealth = 2f;

    
    private Vector2 Herdmovement;

    void TakeDamage(float damage)
    {
        herdHealth -= damage;
        if(herdHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position + new Vector3(0.5f, 1f, 0);
        targetDir.Normalize();
        movement = targetDir;
    }

    void FixedUpdate(){
        move(movement);
    }

    
    
}