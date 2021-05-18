using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFPS : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Application.targetFrameRate = 60;
    }
}
