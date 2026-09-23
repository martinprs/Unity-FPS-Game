using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject HealthPack;
    public GameObject AmmoBox;
    public GameObject itemSpawn;
    
    public void DecreaseHealth()
    {
        health--;

        if (health <= 0)
        {   
            int drop = Random.Range(1, 4);

            if (drop == 1)
            {
                Instantiate(AmmoBox, itemSpawn.transform.position, Quaternion.identity);
            }
            
            else if (drop == 2)
            {
                Instantiate(HealthPack, itemSpawn.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}