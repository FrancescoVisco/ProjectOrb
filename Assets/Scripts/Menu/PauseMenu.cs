using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    bool Exit = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("pauseButton"))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {            
                Pause();
            }
        }

        if(GameIsPaused == true)
        {
            if(Exit == false)
            {
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<FirstPersonAIO>().enabled = false;
                GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = false;
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f; 
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").GetComponent<FirstPersonAIO>().enabled = true;
            GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = true;
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;  
        }
    }



    public void Resume()
    {
        GameIsPaused = false;
    }

    public void Pause()
    {
        GameIsPaused = true;
    }

    public void ExitToMenu()
    {
        Exit = true;
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().transitionTime = 2f;
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = 0;
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
    }
}
