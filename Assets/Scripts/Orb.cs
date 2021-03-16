using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject[] Waypoint;
    private GameObject[] Wall;
    public GameObject WaypointStart;
    public float Speed;
    public int current;
    public int currentmax;
    public bool Forward;
    public bool Active;
    public bool OnWaypoint;
    public bool OnWall;

    void Start()
    {
        current = 0;
        Active = false;
    }

    void Update()
    {
        Waypoint = GameObject.FindGameObjectsWithTag("Waypoint");
        currentmax = Waypoint.Length-1;

        //Activation
        if(Input.GetKeyDown(KeyCode.E) && currentmax != -1)
        {
            Active = true;
            Forward = true;    
        }
    }

    void FixedUpdate()
    {
        //Orb Follow Waypoints
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

                /*if(OnWall == true)
                {
                    current -= 1;
                }*/
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, WaypointStart.transform.position, Time.deltaTime * Speed);  
        }

        
        //Collision Wall settings
        GameObject[]  WallObj = GameObject.FindGameObjectsWithTag("Wall");

        if(OnWaypoint == true && OnWall == true)
        {
            foreach (GameObject obj in WallObj) 
		    {
                Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true); 
            }
        }
        else if (OnWaypoint == false && OnWall == true)
        {
            foreach (GameObject obj in WallObj) 
		    {
                Physics.IgnoreCollision(obj.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if(other.gameObject.tag == "Wall")
            {
                OnWall = true;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if(other.gameObject.tag == "Wall")
            {
                OnWall = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Waypoint")
        {
            OnWaypoint = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Waypoint")
        {
            OnWaypoint = false;
        }
    }
}