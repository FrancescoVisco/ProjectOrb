using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipSound : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Voice;
    private bool Played;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Played == false)
        {
            Source.PlayOneShot(Voice, 0.5f);
            Played = true;
        }
    }
}
