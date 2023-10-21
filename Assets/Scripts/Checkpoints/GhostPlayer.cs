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
        for (int i = 0; i < ghost.timeSlap2.Count - 2; i++)
        {
            if (ghost.timeSlap2[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if (ghost.timeSlap2[i] < timeValue & timeValue < ghost.timeSlap2[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }

            index1 = ghost.timeSlap2.Count - 1;
            index2 = ghost.timeSlap2.Count - 1;
        }
    }

    private void SetTransform()
    {
        if (index1 == index2)
        {
            this.transform.position = ghost.position2[index1];
            this.transform.eulerAngles = ghost.rotation2[index1];
        }
        else
        {
            float interpolationFactor =
                (timeValue - ghost.timeSlap2[index1]) / (ghost.timeSlap2[index2] - ghost.timeSlap2[index1]);

            this.transform.position = Vector3.Lerp(ghost.position2[index1], ghost.position2[index2], interpolationFactor);
            this.transform.eulerAngles =
                Vector3.Lerp(ghost.rotation2[index1], ghost.rotation2[index2], interpolationFactor);
        }
    }
}