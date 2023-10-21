using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    public Ghost ghost;
    private float timeValue;
    private int index1;
    private int index2;

    private void Awake()
    {
        timeValue = 0;
    }


    // Update is called once per frame
    void Update()
    {
        timeValue += Time.unscaledDeltaTime;
        if (ghost.isReplay)
        {
            GetIndex();
            SetTransform();
        }
    }

    private void GetIndex()
    {
        for (int i = 0; i < ghost.timeSlap.Count - 2; i++)
        {
            if (ghost.timeSlap[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if (ghost.timeSlap[i] < timeValue & timeValue < ghost.timeSlap[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }

            index1 = ghost.timeSlap.Count - 1;
            index2 = ghost.timeSlap.Count - 1;
        }
    }

    private void SetTransform()
    {
        if (index1 == index2)
        {
            this.transform.position = ghost.position[index1];
            this.transform.eulerAngles = ghost.rotation[index1];
        }
        else
        {
            float interpolationFactor =
                (timeValue - ghost.timeSlap[index1]) / (ghost.timeSlap[index2] - ghost.timeSlap[index1]);

            this.transform.position = Vector3.Lerp(ghost.position[index1], ghost.position[index2], interpolationFactor);
            this.transform.eulerAngles =
                Vector3.Lerp(ghost.rotation[index1], ghost.rotation[index2], interpolationFactor);
        }
    }
}