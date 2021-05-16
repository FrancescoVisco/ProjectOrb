using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Wind;

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

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Source.PlayOneShot(Wind, 1F);
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;              
        }
    }
}

