using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet0;
    public GameObject bullet1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            Instantiate(bullet0, firePoint.position, firePoint.rotation);
        }
        else
        {
            Instantiate(bullet1, firePoint.position, firePoint.rotation);
        }
    }
}
