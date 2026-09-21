using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public TMP_Text AmmoText;
    public float speed = 100f;
    public float fireRate = 0.2f;
    public float bullets = 30f;
    public float mags = 3f;

    private float nextFireTime;

    void Start()
    {
        AmmoUpdate();
    }

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
        bullets --;
        AmmoUpdate();
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ammo"))
        {
            bullets += 60;
            AmmoUpdate();
            Destroy(col.gameObject);
        }
    }

    void AmmoUpdate()
    {
        AmmoText.text = $"{bullets} / {mags} Bullets";
    }
}