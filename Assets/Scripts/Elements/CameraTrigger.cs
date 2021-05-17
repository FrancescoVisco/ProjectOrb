using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Voice;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && !Source.isPlaying)
        {
            Source.PlayOneShot(Voice, 0.5f);
        }
    }
}
