using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TMP_Text HealthText;
    public float tickRate = 0.5f;

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
            StartCoroutine(DecreaseHealth());

        }

        if (col.CompareTag("Healthpack"))
        {
            health += 100 - health;
            HealthUpdate();
            Destroy(col.gameObject);
        }
    }

    IEnumerator DecreaseHealth()
    {
        while (true)
        {   
            HealthUpdate();

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            yield return new WaitForSeconds(tickRate);

            health -= 25;
        }
    }

    void HealthUpdate()
    {
        HealthText.text = $"Health {health}";
    }
}