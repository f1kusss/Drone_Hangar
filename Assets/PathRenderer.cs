using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public Transform player;
    public LineRenderer lineRenderer;
    public float Fov;
    private Vector3[] linePos;
    private float distance;
    //private Vector3[] reversedLinePos;
    bool flag = false;

    private void Start()
    {
        linePos = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(linePos);
        Array.Reverse(linePos);
        Debug.Log(linePos[0]);
        lineRenderer.SetPositions(linePos);
    }

    private void Update()
    {
        if (lineRenderer.positionCount >= 1)
        {
           distance = Vector3.Distance(player.position, linePos[lineRenderer.positionCount - 1]);
        }
        

        if (distance <= Fov)
        {
            if (lineRenderer.positionCount >= 1)
            {
                lineRenderer.positionCount -= 1;
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
    }
}
