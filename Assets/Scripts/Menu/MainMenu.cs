using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject ControlsPanel;
    
    void Start () 
    {
        Cursor.lockState = CursorLockMode.None;
        MainPanel.SetActive(true);
        ControlsPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Controls()
    {
        MainPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void Back()
    {
        MainPanel.SetActive(true);
        ControlsPanel.SetActive(false);
    }

    public void NewGame()
    {
        //GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = 1;
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
