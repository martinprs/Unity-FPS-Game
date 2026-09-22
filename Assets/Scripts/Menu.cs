using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject ObjectiveCanvas;
    public GameObject ControlsCanvas;

    public void Start()
    {
        MenuCanvas.SetActive(true);
        ObjectiveCanvas.SetActive(false);
        ControlsCanvas.SetActive(false);
    }

    public void SetObjectiveCanvas()
    {
        MenuCanvas.SetActive(false);
        ObjectiveCanvas.SetActive(true);
        ControlsCanvas.SetActive(false);
    }

    public void SetControlsCanvas()
    {
        MenuCanvas.SetActive(false);
        ObjectiveCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
    }

    public void PlayGame()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
