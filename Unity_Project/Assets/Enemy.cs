using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float timeLeft = 4.0f;
    public GameObject deathEffect;
    Vector2 v = Vector2.right;
    public GameObject yay;

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(v * 250 * Time.deltaTime);
        yay = GameObject.Find("birthday");
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            v = -v;
            timeLeft = 4.0f; 
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
        Destroy(Instantiate(deathEffect, new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, -5), Quaternion.identity), 2);

        ScreamSound s = (ScreamSound)yay.GetComponent<ScreamSound>();
        s.Scream();
    }

}
