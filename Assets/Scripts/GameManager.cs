using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text TimerText;
    public float time = 300f; // 5 minutes
    public GameObject Enemy;
    public GameObject[] EnemySpawns;

    private bool enableTimer = true;
    private float spawnTimer;

    private MenuManager menuManager;
    private CameraLook cameraLook;
    private PlayerMove playerMove;
    private EnemyFollow[] enemyFollows;
    private Shoot shoot;
    private ItemAnimation[] itemAnimations;

    void Update()
    {
        if (enableTimer)
        {
            Timer();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuManager.PauseMenu();
            FreezeGame(true);
        }
    }

    void SpawnEnemy()
    {
        foreach (GameObject spawnPoint in EnemySpawns)
        {
            Instantiate(Enemy, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    private void Awake()
    {
        menuManager = GetComponent<MenuManager>();
        cameraLook = GetComponentInChildren<CameraLook>();
        playerMove = GetComponent<PlayerMove>();
        enemyFollows = FindObjectsOfType<EnemyFollow>();
        shoot = GetComponent<Shoot>();
        itemAnimations = FindObjectsOfType<ItemAnimation>();
    }

    public void FreezeGame(bool enabled)
    {
        if (enabled)
        {
            enableTimer = false;
            cameraLook.Look(false);
            playerMove.Move(false);
            shoot.ShootBullet(false);
            foreach (EnemyFollow enemy in enemyFollows)
            {
                enemy.Move(false);
            }
            foreach (ItemAnimation item in itemAnimations)
            {
                item.Animate(false);
            }
        }
        else
        {
            enableTimer = true;
            cameraLook.Look(true);
            playerMove.Move(true);
            shoot.ShootBullet(true);
            foreach (EnemyFollow enemy in enemyFollows)
            {
                enemy.Move(true);
            }
            foreach (ItemAnimation item in itemAnimations)
            {
                item.Animate(true);
            }
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
        
        if (time <= 0)
        {
            time = 0;
            PlayerWin();
        }
        else
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= 5f)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        TimerText.text = string.Format("{00:00}:{1:00} Remaining", minutes, seconds);
    }
};
