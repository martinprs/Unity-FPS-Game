using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private float speed = 3f;

    void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void Move(bool enabled)
    {
        if (!enabled)
        {
            speed = 0;
        }
        else
        {
            speed = 3f;
        }
    }
}