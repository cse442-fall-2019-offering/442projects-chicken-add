using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    float timeLeft = 2.0f;
    Vector2 v = Vector2.right;
    
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(v * 300 * Time.deltaTime);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            v = -v;
            timeLeft = 2.0f; 
        }  
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
