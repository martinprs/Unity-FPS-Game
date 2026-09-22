using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text TimerText;
    public float time = 300f; // 5 minutes

    private bool enableTimer = true;

    private MenuManager menuManager;
    private CameraLook cameraLook;
    private PlayerMove playerMove;
    private EnemyFollow[] enemyFollows;
    private Shoot shoot;
    private ItemAnimation itemAnimation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enableTimer)
        {
            Timer();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            FreezeGame(true);
        }
    }

    private void Awake()
    {
        menuManager = GetComponent<MenuManager>();
        cameraLook = GetComponentInChildren<CameraLook>();
        playerMove = GetComponent<PlayerMove>();
        enemyFollows = FindObjectsOfType<EnemyFollow>();
        shoot = GetComponent<Shoot>();
        itemAnimation = GetComponentInChildren<ItemAnimation>(true);
    }

    void FreezeGame(bool enabled)
    {
        if (enabled)
        {
            enableTimer = false;
            cameraLook.Look(false);
            playerMove.Move(false);
            foreach (EnemyFollow enemy in enemyFollows)
            {
                enemy.Move(false);
            }
            shoot.ShootBullet(false);
            itemAnimation.Animate(false);
            enableTimer = false;
        }
        else
        {
            enableTimer = true;
            cameraLook.Look(true);
            playerMove.Move(true);
            foreach (EnemyFollow enemy in enemyFollows)
            {
                enemy.Move(true);
            }
            shoot.ShootBullet(true);
            itemAnimation.Animate(true);
            enableTimer = true;
        }
    }

    void PlayerWin()
    {
        menuManager.GameEndMenu("You win! :)");
        FreezeGame(true);
    }

    public void PlayerLose()
    {
        menuManager.GameEndMenu("You lose! :(");
        FreezeGame(true);
    }

    void Timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 0)
        {
            time = 0;
            PlayerWin();
        }
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        TimerText.text = string.Format("{00:00}:{1:00} Remaining", minutes, seconds);
    }
}
