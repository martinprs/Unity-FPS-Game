using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{   
    public GameObject GameCanvas;
    public GameObject MenuCanvas;
    public GameObject GameEndCanvas;
    public TMP_Text Header;

    private GameManager gameManager;

    void Start()
    {
        GameCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        GameEndCanvas.SetActive(false);
        Header.text = "";
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void GameEndMenu(string text)
    {
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        GameEndCanvas.SetActive(true);
        Header.text = text;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseMenu()
    {
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        GameEndCanvas.SetActive(false);
        Header.text = "Paused";
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {   
        Start();
        gameManager.FreezeGame(false);
    }

    public void RestartGame()
    {   
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitGame()
    {
        // load to mainmenu scene
    }
}
