using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private int ThisScene;
    
    void Start()
    {
        ThisScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<FirstPersonAIO>().enabled = false;
            GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = false;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().transitionTime = 2f;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = ThisScene+1;
        }
    }
}
