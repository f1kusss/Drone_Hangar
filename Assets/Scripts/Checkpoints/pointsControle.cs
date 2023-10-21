using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class pointsControle : MonoBehaviour
{
    public Transform checkpointHolder;
    public int currentCheckpointIndex = 0;
    public List<Transform> checkpoints;
    public Timer timer;
    public Save save;

    void Start()
    {
        save = FindObjectOfType<Save>();
        timer = FindObjectOfType<Timer>();
        timer.StratPointsTime();
        if (PlayerPrefs.HasKey("SavedFloat"))
        {
            save.LoadGame();
        }
        else ;
        foreach (Transform children in checkpointHolder)
        {
            checkpoints.Add(children);
            Debug.Log(children);
        }

        foreach (Transform child in checkpoints)
        {
            child.gameObject.SetActive(false);
        }
        checkpoints[0].gameObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        save.SaveGame();
    }

    public void NextPoint()
    {
        timer.ResetPointsTime();
        if (currentCheckpointIndex == 0)
        {
            timer.StartStopwatch();
        }
        checkpoints[currentCheckpointIndex].gameObject.SetActive(false);
        if (currentCheckpointIndex < checkpoints.Count - 1)
        {
            checkpoints[++currentCheckpointIndex].gameObject.SetActive(true);
        }
        else
        {
            timer.ResetStopwatch();
            currentCheckpointIndex = 0;
            checkpoints[currentCheckpointIndex].gameObject.SetActive(true);
        }
        
    }
    
}