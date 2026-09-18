using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TMP_Text HealthText; 
    
    void Start()
    {
        HealthUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            health--;
            HealthUpdate();
            Destroy(col.gameObject);

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (col.CompareTag("Healthpack"))
        {
            health++;
            HealthUpdate();
            Destroy(col.gameObject);
        }
    }

    void HealthUpdate()
    {
        HealthText.text = $"Health {health}";
    }
}