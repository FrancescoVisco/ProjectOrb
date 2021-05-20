using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTool : MonoBehaviour
{
    public GameObject Tool;
    public AudioClip Voice; 
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Delay());
            Tool.SetActive(true);
            GameObject.Find("Player").GetComponent<SpawnWaypoint>().enabled = true;
            GameObject.Find("Player").GetComponent<Tool>().ToolObtained = true;  
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
        GameObject.Find("Player").GetComponent<SpawnWaypoint>().Source.PlayOneShot(Voice, 0.5f);
    }
}
