using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject HealthPack;
    public GameObject AmmoBox;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseHealth()
    {
        health--;

        if (health <= 0)
        {
            Instantiate(AmmoBox, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}