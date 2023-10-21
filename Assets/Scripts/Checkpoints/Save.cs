using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavedFloat", timer.saveTime.bestTime);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        timer.saveTime.bestTime = PlayerPrefs.GetFloat("SavedFloat");
        Debug.Log("Game data loaded!");
    }

    // void ResetData()
    // {
    //     PlayerPrefs.DeleteAll();
    //     intToSave = 0;
    //     floatToSave = 0.0f;
    //     stringToSave = "";
    //     Debug.Log("Data reset complete");
    // }
}