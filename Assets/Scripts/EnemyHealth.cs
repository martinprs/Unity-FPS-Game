using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject HealthPack;
    public GameObject AmmoBox;
    public Transform itemSpawn;
    
    public void DecreaseHealth()
    {
        health--;

        if (health <= 0)
        {   
            int drop = Random.Range(1, 4);
            Transform spawnPoint = itemSpawn != null ? itemSpawn : transform.Find("ItemSpawn");
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;

            if (drop == 1)
            {
                Instantiate(AmmoBox, spawnPosition, Quaternion.identity);
            }
            
            else if (drop == 2)
            {
                Instantiate(HealthPack, spawnPosition, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}