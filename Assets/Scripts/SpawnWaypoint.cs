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
    public int MaxWaipoints;
    private int WaypointLights;

    [Header("Waypoint Lights Settings")]
    public GameObject[] WaypointLight;
    public Material[] WaypointLightMaterial;
    public bool Respawn = false;

    [Header("Audio Settings")]
    public AudioClip WaypointPlacement;
    public AudioClip NegativePlacement;
    private AudioSource Source;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Place Waypoint
        WaypointsObj = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointLights = MaxWaipoints - WaypointsCounter;

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
                else if(!Source.isPlaying)
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

        //Change Tool Lights Material
        if(GameObject.Find("Orb").GetComponent<Orb>().Arrived == false && Respawn == false)
        {
            if(WaypointLights == 0)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
            }
            else if(WaypointLights == 1)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
            }
            else if(WaypointLights == 2)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
            }
            else if(WaypointLights == 3)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
            }
            else if(WaypointLights == 4)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
            }

            if(Orb.GetComponent<Orb>().MatOn == true)
            {
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else
            {
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[2];
            }
        }
        else if(GameObject.Find("Orb").GetComponent<Orb>().Arrived == true && Respawn == true)
        {
            WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
            WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
            WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
            WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
            WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
        } 
    }
}
