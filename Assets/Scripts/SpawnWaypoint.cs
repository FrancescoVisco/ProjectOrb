using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject WaypointStart;

    [Header("Waypoint Lights Settings")]
    public GameObject[] WaypointLight;
    public Material[] WaypointLightMaterial;
    public bool Respawn = false;

    [Header("Audio Settings")]
    public AudioClip WaypointPlacement;
    public AudioClip NegativePlacement;
    public AudioSource Source;

    public int ThisScene;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        WaypointStart = Orb.GetComponent<Orb>().WaypointStart;
        ThisScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Update()
    {
        Physics.IgnoreLayerCollision(7, 6, true);
        //Place Waypoint
        WaypointsObj = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointLights = MaxWaipoints - WaypointsCounter;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.transform.tag == "WaypointWall" && WaypointsCounter < MaxWaipoints) && Respawn == false)
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

        if(Input.GetMouseButtonDown(1) && Orb.GetComponent<Orb>().Active == false && GameObject.Find("Orb").GetComponent<Orb>().OnStart == true && Respawn == false)
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

            if(GameObject.Find("Orb").GetComponent<Orb>().OnStart == true)
            {
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(GameObject.Find("Orb").GetComponent<Orb>().OnStart == false)
            {
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[2];
            }
        }
        else if(GameObject.Find("Orb").GetComponent<Orb>().Arrived == true && Respawn == true)
        {
            if(ThisScene == 1 || ThisScene == 2)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(ThisScene == 3)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(ThisScene == 4)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(ThisScene == 5)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(ThisScene == 6)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[0];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
            else if(ThisScene == 7)
            {
                WaypointLight[1].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[2].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[3].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[4].GetComponent<MeshRenderer>().material = WaypointLightMaterial[1];
                WaypointLight[0].GetComponent<MeshRenderer>().material = WaypointLightMaterial[3];
            }
        } 
    }
}
