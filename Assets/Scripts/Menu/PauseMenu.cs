using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CMF
{
    public class PauseMenu : MonoBehaviour
    {

        public bool GameIsPaused = false;
        public bool Tool;
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
                    GameObject.Find("CameraControls").GetComponent<CameraController>().enabled = false;
                    PauseMenuUI.SetActive(true);
                    Time.timeScale = 0f;

                    if(GameObject.Find("Player").GetComponent<Tool>().ToolObtained == true)
                    {
                        GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = false;
                    }
                }
                else
                {
                    Time.timeScale = 1f; 
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.Find("CameraControls").GetComponent<CameraController>().enabled = true;
                PauseMenuUI.SetActive(false);
                Time.timeScale = 1f;  

                    if(GameObject.Find("Player").GetComponent<Tool>().ToolObtained == true)
                    {
                        GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = true;
                    }
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
}