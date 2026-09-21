using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float lifeTime = 1f;
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.root.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
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