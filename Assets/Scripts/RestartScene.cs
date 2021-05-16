using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;              
        }

        if(GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad == 0)
        {
            Destroy(gameObject);
        }
    }
}

