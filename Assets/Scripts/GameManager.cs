using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text TimerText;
    public float timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = $"{timer} Remaining";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
