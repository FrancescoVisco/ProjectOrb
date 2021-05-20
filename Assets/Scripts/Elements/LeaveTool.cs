using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTool : MonoBehaviour
{
    public GameObject Tool;
    public AudioClip Voice; 
    public GameObject Door;
    public GameObject ObjToActive;
    public AudioSource Source;
    public bool Played;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Played == false)
        {
            Tool.SetActive(false);
            ObjToActive.SetActive(true);
            Door.GetComponent<Activation>().Active = true;
            GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = false;  
            GameObject.Find("Player").GetComponent<Tool>().ToolObtained = false;  
            Source.PlayOneShot(Voice, 1f);  
            Played = true;
        }
    }
}
