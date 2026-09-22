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

    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        GameEndCanvas.SetActive(false);
    }

    public void EndGame(string text)
    {
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        GameEndCanvas.SetActive(true);
        Header.text = text;
    }
}
