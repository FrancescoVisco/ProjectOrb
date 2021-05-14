using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    public GameObject ObjectToActivate;

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
            ObjectToActivate.GetComponent<Activation>().Active = false;
            //Destroy(GameObject.Find("Orb"));
        }
    }
}
