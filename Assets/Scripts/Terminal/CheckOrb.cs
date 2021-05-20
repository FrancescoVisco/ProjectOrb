using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrb : MonoBehaviour
{
    public GameObject ObjectToActivate;
    public bool BasicLevel;
    public bool CorrectColor;
    private GameObject Orb;

    public bool Red;
    public bool Blue;
    public bool Yellow;
    public bool Green;
    public bool Orange;
    public bool Violet;
    public bool White;
    public Material[] mat; 

    void Start()
    {
        Orb = GameObject.FindGameObjectWithTag("Orb");
    }

    void Update()
    {
        //Material Change
        if(Red == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[0];
        }
        else if(Blue == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[1];
        }
        else if(Yellow == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[2];
        }
        else if(Green == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[3];
        }
        else if(Orange == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[4];
        }
        else if(Violet == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[5];
        }
        else if(White == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[6];
        }
        else if (Red == false && Blue == false && Yellow == false && Green == false && Orange == false && Violet == false && White == false)
       {
           gameObject.GetComponent<MeshRenderer>().material = mat[7];
       }

        //Check color
        if(Red == true && Orb.GetComponent<Orb>().Red == true && Orb.GetComponent<Orb>().Yellow == false && Orb.GetComponent<Orb>().Blue == false)
        {
            CorrectColor = true;
        }
        else if(Blue == true && Orb.GetComponent<Orb>().Blue == true && Orb.GetComponent<Orb>().Yellow == false && Orb.GetComponent<Orb>().Red == false)
        {
            CorrectColor = true;
        }
        else if(Yellow == true && Orb.GetComponent<Orb>().Yellow == true && Orb.GetComponent<Orb>().Blue == false && Orb.GetComponent<Orb>().Red == false)
        {
            CorrectColor = true;
        }
        else if(Green == true && Orb.GetComponent<Orb>().Blue == true && Orb.GetComponent<Orb>().Yellow == true && Orb.GetComponent<Orb>().Red == false)
        {
            CorrectColor = true;
        }
        else if(Orange == true && Orb.GetComponent<Orb>().Red == true && Orb.GetComponent<Orb>().Yellow == true && Orb.GetComponent<Orb>().Blue == false)
        {
            CorrectColor = true;
        }
        else if(Violet == true && Orb.GetComponent<Orb>().Red == true && Orb.GetComponent<Orb>().Blue == true && Orb.GetComponent<Orb>().Yellow == false)
        {
            CorrectColor = true;
        }
        else if(White == true && Orb.GetComponent<Orb>().Red == true && Orb.GetComponent<Orb>().Blue == true && Orb.GetComponent<Orb>().Yellow == true)
        {
            CorrectColor = true;
        }
        else
        {
            CorrectColor = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Orb" && (CorrectColor == true || BasicLevel == true))
        {
            other.gameObject.GetComponent<Orb>().Arrived = true;
            other.gameObject.GetComponent<Orb>().Source.PlayOneShot(other.gameObject.GetComponent<Orb>().Correct, 0.6F);  
            ObjectToActivate.GetComponent<Activation>().Active = true;
        }
    }
}
