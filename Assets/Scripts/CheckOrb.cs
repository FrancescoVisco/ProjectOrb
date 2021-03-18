using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrb : MonoBehaviour
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
        if(other.gameObject.tag == "Orb")
        {
            other.gameObject.GetComponent<Orb>().Arrived = true;
            ObjectToActivate.GetComponent<Activation>().Active = true;
        }
    }
}
