using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pointsControle : MonoBehaviour
{
    public Transform checkpointHolder;
    public int currentCheckpointIndex = 0;
    public List<Transform> checkpoints;
    public Timer timer;
    public GameObject panel;
    public MenuController mainCamera;

    

    void Start()
    {
        
        timer = FindObjectOfType<Timer>();
        if (PlayerPrefs.HasKey("SavedFloat"))
        {
            //save.LoadGame();
        }
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
        //save.SaveGame();
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
            //mainCamera.openMenu();
            //panel.SetActive(true);
			timer.ResetStopwatch();
			//Time.timeScale = 0;
            //SceneManager.LoadScene("Hangar");
        }
        
    }

    public void GetCurrentCheckPoint()
    {

    }

    public void RestartScene()
    {
		SceneManager.LoadScene("Hangar");
		panel.SetActive(false);
		Time.timeScale = 1;
	}
    
}