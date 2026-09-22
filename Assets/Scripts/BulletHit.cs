using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float lifeTime = 1f;
    public EnemyHealth enemyHealth;

    void Start()
    {
        Destroy(transform.root.gameObject, lifeTime);
    }

    private void Awake()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        Destroy(transform.root.gameObject);
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.DecreaseHealth();
        }
    }

}