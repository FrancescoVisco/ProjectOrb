using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decontamination : MonoBehaviour
{
    [Header("Waypoint Settings")]
    public AudioSource Source;
    public AudioClip DecontaminationSound;

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.GetComponent<SpawnWaypoint>().Respawn == false)
        {
            other.GetComponent<SpawnWaypoint>().Respawn = true;
            Source.PlayOneShot(DecontaminationSound, 0.7F);
            StartCoroutine(DecontaminationCoroutine());
        }
    }

    IEnumerator DecontaminationCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
