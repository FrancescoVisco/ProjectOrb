using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public int ThisScene;
    private bool InTrigger = false;
    
    void Start()
    {
        ThisScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if(InTrigger == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonAIO>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWaypoint>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InTrigger = true;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().transitionTime = 2f;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = ThisScene+1;
        }
    }
}
