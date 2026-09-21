using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float speed = 100f;
    public float fireRate = 0.2f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        b.GetComponent<Rigidbody>().velocity = shootPoint.forward * speed;
    }
}