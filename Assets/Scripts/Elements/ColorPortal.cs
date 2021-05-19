using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPortal : MonoBehaviour
{

    [Header("Material Setting")]
    public bool Red;
    public bool Blue;
    public bool Yellow;
    public Material[] PortalMat;

    void Start()
    {

    }

    void Update()
    {
        //Material Change
        if(Red == true && Blue == false && Yellow == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = PortalMat[0];
        }
        else if(Red == false && Blue == true && Yellow == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = PortalMat[1];
        }
        else if(Red == false && Blue == false && Yellow == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = PortalMat[2];
        }
    } 
}
