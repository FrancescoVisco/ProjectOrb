using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    public LineRenderer lr;
    public List<GameObject> pos;

    void Start()
    {
        
    }

    void Update()
    {
        pos = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Respawn"));
        pos.AddRange (new List<GameObject> (GameObject.FindGameObjectsWithTag ("Waypoint")));
        int Lengthlr = pos.Count;
        lr.positionCount = Lengthlr;

        for (int i = 0; i < Lengthlr; i++)
        {
            lr.SetPosition(i, pos[i].transform.position);
        }
    }
}
