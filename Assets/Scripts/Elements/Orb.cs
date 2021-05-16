using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [Header("Target Settings")]
    public GameObject[] Waypoint;
    private GameObject[] Wall;
    public GameObject WaypointStart;
    public GameObject WaypointEnd;
    public float Speed;

    [Header("Material Setting")]
    public bool Red;
    public bool Blue;
    public bool Yellow;
    public Material[] OrbMat;

    [Header("Debug")]
    public bool Active;
    public bool Arrived;
    private int current;
    public int currentmax;
    private bool Forward;
    private bool OnWaypoint;
    private bool OnWall;
    public bool MatOn;

    [Header("Audio Settings")]
    public AudioClip LaunchOrb;
    public AudioClip NegativeLaunch;
    public AudioClip Correct;
    public AudioClip Error;
    public AudioSource Source;
    
    void Start()
    {
        current = 0;
        Active = false;
        Source = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    void Update()
    {
        Waypoint = GameObject.FindGameObjectsWithTag("Waypoint");
        currentmax = Waypoint.Length-1;

        //Activation
        if(Input.GetKeyDown(KeyCode.E) && transform.position == WaypointStart.transform.position && currentmax > -1)
        {
            Active = true;
            Forward = true;    
            Source.PlayOneShot(LaunchOrb, 0.5F);
        }
        else if(Input.GetKeyDown(KeyCode.E) && !Source.isPlaying)
        {
            Source.PlayOneShot(NegativeLaunch, 0.25F);
        }

        //Material Change
        if(Red == true && Blue == false && Yellow == false)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[0];
       }
        else if(Red == false && Blue == true && Yellow == false)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[1];
       }
        else if(Red == false && Blue == false && Yellow == true)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[2];
       }
        else if(Red == false && Blue == true && Yellow == true)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[3];
       }
        else if(Red == true && Blue == false && Yellow == true)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[4];
       }
        else if(Red == true && Blue == true && Yellow == false)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[5];
       }
        else if(Red == true && Blue == true && Yellow == true)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[6];
       }
        else if (Red == false && Blue == false && Yellow == false)
       {
           gameObject.GetComponent<MeshRenderer>().material = OrbMat[7];
       }

       if(transform.position == WaypointStart.transform.position)
       {
           MatOn = true;
       }
       else
       {
           MatOn = false;
       }
    }

    void FixedUpdate()
    {
        Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);

        //Orb Follow Waypoints
        if(Arrived == false)
        {
            if(Active == true)
            {
                if(Forward == true)
                {  
                    if(transform.position == Waypoint[current].transform.position)
                    { 
                        if(current < currentmax)
                        {
                            current += 1;              
                        }
                        else if(current == currentmax) 
                        {
                            Forward = false;
                            Source.PlayOneShot(Error, 1F); 
                        }      
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, Waypoint[current].transform.position, Time.deltaTime * Speed); 
                    }
                }
                else if(Forward == false)
                {                                       
                    if(transform.position == Waypoint[current].transform.position)
                    {    
                        if(current > 0)
                        { 
                            current -= 1;
                        }
                        else if(current == 0)
                        {
                            Active = false;
                        }    
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, Waypoint[current].transform.position, Time.deltaTime * Speed); 
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, WaypointStart.transform.position, Time.deltaTime * Speed);
            }
            
            //Collision Wall settings
            GameObject[]  WallObj = GameObject.FindGameObjectsWithTag("WaypointWall");
            GameObject[]  NoWallObj = GameObject.FindGameObjectsWithTag("NoWall");

            if(OnWaypoint == true)
            {
                foreach (GameObject obj in WallObj) 
                {
                    Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true); 
                }

                foreach (GameObject obj in NoWallObj) 
                {
                    Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true); 
                }
            }
            else if (OnWaypoint == false)
            {
                foreach (GameObject obj in WallObj) 
                {
                    Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
                }

                foreach (GameObject obj in NoWallObj) 
                {
                    Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
                }
            }

            if(OnWall == true && OnWaypoint == false)
            {
                Forward = false;
                Source.PlayOneShot(Error, 1F);             
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, WaypointEnd.transform.position, Time.deltaTime * Speed); 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "NoWall")
        {
            OnWall = true;

            if(current > 0)
            {
                current -= 1;
            }
            else
            {
                Active = false;
            }        
        }        
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "NoWall")
        {
            OnWall = false;
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Waypoint" || other.gameObject.tag == "Respawn")
        {
            OnWaypoint = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Waypoint" || other.gameObject.tag == "Respawn")
        {
            OnWaypoint = false;
        }
    }
}