using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text TimerText;
    public float time = 300f; // 5 minutes

    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Timer();
    }

    private void Awake() {
        menuManager = GetComponent<MenuManager>();
    }

    void FreezeGame(bool enabled)
    {
        if (enabled)
        {
            // freeze game
        }
        else
        {
            // unfreeze game
        }
    }

    void PlayerWin()
    {   
        FreezeGame(true);
        menuManager.GameEndMenu("You win! :)");
    }

    public void PlayerLose() {
        FreezeGame(true);
        menuManager.GameEndMenu("You lose! :(");
    }

    void Timer() {
        if (time > 0) {
            time -= Time.deltaTime;
        }
        else if (time < 0) {
            time = 0;
            PlayerWin();
        }
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        TimerText.text = string.Format("{00:00}:{1:00} Remaining", minutes, seconds);
    }
}
