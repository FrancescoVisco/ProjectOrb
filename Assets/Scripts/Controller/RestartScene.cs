using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Wind;
    public int ThisScene;
    public int SceneToLoad;

    void Start()
    {
        
    }
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        ThisScene = ThisScene = SceneManager.GetActiveScene().buildIndex;

        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;              
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            if(ThisScene == 9)
            {
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = 0;
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;  
            }
            else
            {
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = SceneManager.GetActiveScene().buildIndex+1;
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;  
            }
        }

        if(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad == 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Source.PlayOneShot(Wind, 1F);
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = SceneToLoad;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;              
        }
    }
}

