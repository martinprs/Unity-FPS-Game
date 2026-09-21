using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public TMP_Text AmmoText;
    public TMP_Text ReloadText;
    public float speed = 100f;
    public float fireRate = 0.2f;
    public float bullets = 30f;
    public float mags = 3f;
    public float reloadTime = 1f;

    private float nextFireTime;
    private bool isReloading;

    void Start()
    {
        AmmoUpdate();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !isReloading && Time.time >= nextFireTime && bullets > 0)
        {
            nextFireTime = Time.time + fireRate;
            ShootBullet();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && bullets < 30f && mags > 0)
        {
            StartCoroutine(Reload());
        }
    }

    void ShootBullet()
    {
        GameObject b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        b.GetComponent<Rigidbody>().velocity = shootPoint.forward * speed;
        bullets--;
        AmmoUpdate();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ammo"))
        {
            mags += 1;
            AmmoUpdate();
            Destroy(col.gameObject);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ReloadText.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);
        ReloadText.text = "";
        bullets = 30f;
        mags--;
        isReloading = false;
        AmmoUpdate();
    }

    void AmmoUpdate()
    {
        AmmoText.text = $"{bullets} / {mags} Bullets";
    }
}