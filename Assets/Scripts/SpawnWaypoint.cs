using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaypoint : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Waypoint;
    public GameObject Orb;
    private GameObject[] WaypointsObj;
    public int WaypointsCounter;
    public int MaxWaipoints = 3;
    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        WaypointsObj = GameObject.FindGameObjectsWithTag("Waypoint");

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Wall" && WaypointsCounter < MaxWaipoints)
                {
                    Instantiate(Waypoint, hit.point, Quaternion.identity);
                    WaypointsCounter++;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && Orb.GetComponent<Orb>().Active == false)
        {    
            foreach(GameObject obj in WaypointsObj)
            {
                GameObject.Destroy(obj);       
                WaypointsCounter = 0;
            }  
        }
    }
}
