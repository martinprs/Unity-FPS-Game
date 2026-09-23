using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float lifeTime = 1f;

    void Start()
    {
        Destroy(transform.root.gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider col)
    {
        EnemyHealth enemyHealth = col.GetComponentInParent<EnemyHealth>();

        enemyHealth.DecreaseHealth();

        Destroy(transform.root.gameObject);
    }

}