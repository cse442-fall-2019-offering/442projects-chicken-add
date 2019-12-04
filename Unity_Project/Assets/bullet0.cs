using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet0 : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.GetComponent<Player>();
        playerbullet1 b1 = collision.GetComponent<playerbullet1>();
        playerbullet0 pb0 = collision.GetComponent<playerbullet0>();
        //make it so that when player bullets collide with enemy bullets they dont destroy the enemy bullets
        if (b1 != null || pb0 != null)
        {
            return;
        }
        if(p != null)
        {
            p.DamagePlayer(9999);
        }
        Destroy(gameObject);

    }
}
