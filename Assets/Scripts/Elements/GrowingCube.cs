using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingCube : MonoBehaviour
{
    [SerializeField]
    float speed;
 
    [SerializeField]
    Transform startPoint, endPoint;
 
    [SerializeField]
    public bool Lift;
    public AudioSource Source;
    public AudioClip LiftSound;
 
    
    private Transform destinationTarget, departTarget;
    private float InterpolateTime;
 
 
    
    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;
        Source = GetComponent<AudioSource>();
    }
 
   
    void FixedUpdate()
    {
        if(Lift == false)
        {
            Move();
        }
    }
 
    private void Move()
    {      
        if(Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
        {   
            InterpolateTime += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, InterpolateTime);
        }
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Source.PlayOneShot(LiftSound, 1F);
            Lift = false;
        }
    }
}
