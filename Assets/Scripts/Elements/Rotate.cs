using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    float RotateSpeed ;
    float x;
    float y;
    float z;
    public bool RotateOnX;
    public bool RotateOnY;
    public bool RotateOnZ;
    public bool ObjectRotating;
    public bool PlatformRotating;


    void Update()
    {
        if(ObjectRotating == true && GameObject.Find("CanvasPause").GetComponent<PauseMenu>().GameIsPaused == false)
        {
            RotateSpeed = 0.08f;
        }else if(PlatformRotating == true && GameObject.Find("CanvasPause").GetComponent<PauseMenu>().GameIsPaused == false)
        {
            RotateSpeed = 0.25f;
        }


        if(RotateOnX == true)
        {
            x = RotateSpeed;
            y = 0;
            z = 0;
        }

        if (RotateOnY == true)
        {
            x = 0;
            y = RotateSpeed;
            z = 0;
        }

        if (RotateOnZ == true)
        {
            x = 0;
            y = 0;
            z = RotateSpeed;
        }

        transform.Rotate(x, y, z);




        if (ObjectRotating == true)
        {
            if (GameObject.Find("CanvasPause").GetComponent<PauseMenu>().GameIsPaused == true)
            {
                RotateSpeed = 0;
            }
            else
            {
                RotateSpeed = 0.7f;
            }
        }


        if (PlatformRotating == true)
        {
            if (GameObject.Find("CanvasPause").GetComponent<PauseMenu>().GameIsPaused == true)
            {
                RotateSpeed = 0;
            }
            else
            {
                RotateSpeed = 0.25f;
            }
        }
    }
}
