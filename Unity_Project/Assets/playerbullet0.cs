using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet0 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float dist = findDistance(gameObject, GameObject.FindGameObjectWithTag("Player"));
        Enemy enemy = collision.GetComponent<Enemy>();
        bullet0 b = collision.GetComponent<bullet0>();
        if (b != null)
        {
            return;
        }
        if (enemy != null && dist < 20)
        {
            enemy.takeDamage(10);
        }
        Destroy(gameObject);
    }

    public float findDistance(GameObject go1, GameObject go2)
    {
        if (go1 == null || go2 == null)
        {
            return -1;
        }
        else
        {
            return Vector2.Distance(go1.transform.position, go2.transform.position);
        }

    }

}
