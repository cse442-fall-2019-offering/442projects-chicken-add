using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet0 : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.GetComponent<Player>();
        if(p != null)
        {
            p.DamagePlayer(9999);
        }
        Destroy(gameObject);

    }
}
