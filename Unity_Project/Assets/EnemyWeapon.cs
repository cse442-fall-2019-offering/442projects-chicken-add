using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    float timeLeft = 2.0f;

    private void Start()
    {
        firepoint.Rotate(0f, 180f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") != null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            float dist = findDistance(GameObject.FindGameObjectWithTag("Enemy"), GameObject.FindGameObjectWithTag("Player"));
           // Debug.Log(dist);
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0 && dist < 18.0f)
            {
                Shoot();
                timeLeft = 2.0f;
            }

        }
    
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    public float findDistance(GameObject go1, GameObject go2)
    {
        if(go1 == null || go2 == null)
        {
            return -1;
        }
        else
        {
            return Vector2.Distance(go1.transform.position, go2.transform.position);
        }

    }
}