using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float lifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.root.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        Destroy(transform.root.gameObject);
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }

}