using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaypoint : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Camera MainCamera;
    RaycastHit hit;

    [Header("Waypoint Settings")]
    public GameObject Waypoint;
    public GameObject Orb;
    private GameObject[] WaypointsObj;
    public int WaypointsCounter;
    public int MaxWaipoints = 3;

    [Header("Audio Settings")]
    private AudioSource Source;
    public AudioClip WaypointPlacement;
    public AudioClip NegativePlacement;

    void Start()
    {
        Source = GetComponent<AudioSource>();
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
                if (hit.transform.tag == "WaypointWall" && WaypointsCounter < MaxWaipoints)
                {
                    Source.PlayOneShot(WaypointPlacement, 0.7F);
                    Instantiate(Waypoint, hit.point, Quaternion.identity);
                    WaypointsCounter++;
                }
                else
                {
                    Source.PlayOneShot(NegativePlacement, 0.25F);
                }
            }
        }

        if(Input.GetMouseButtonDown(1) && Orb.GetComponent<Orb>().Active == false)
        {    
            foreach(GameObject obj in WaypointsObj)
            {
                GameObject.Destroy(obj);       
                WaypointsCounter = 0;
            }  
        }
    }
}
