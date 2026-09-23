using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            SpawnEnemy();
        }  
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
