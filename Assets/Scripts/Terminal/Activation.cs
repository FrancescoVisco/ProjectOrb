using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public bool Active;

    void Start()
    {
        
    }

    void Update()
    {
        if(Active == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            
            GameObject[] WaypointsObj;
            WaypointsObj = GameObject.FindGameObjectsWithTag("Waypoint");

            foreach(GameObject obj in WaypointsObj)
            {
                GameObject.Destroy(obj);       
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWaypoint>().WaypointsCounter = 0;
            }  
        }
    }
}
