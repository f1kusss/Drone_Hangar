using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject[] checkpoints;
    private int currentCheckpointIndex = 0;

    private void Start()
    {
        Debug.Log("11111111111111111111111111111111111111111111111111111111111111111111111111111");
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        Debug.Log($"11111111111111111111111111111111111111111111111111111111111111111111 {allChildren}");
        checkpoints = new GameObject[allChildren.Length - 1]; // Вычитаем 1, чтобы исключить сам контейнер
        int index = 0;
        foreach (Transform child in allChildren)
        {
            if (child != transform)
            {
                checkpoints[index] = child.gameObject;
                index++;
            }
        }
        SetCheckpointsActive();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentCheckpointIndex < checkpoints.Length)
        {
            checkpoints[currentCheckpointIndex].SetActive(false);
            currentCheckpointIndex++;
            SetCheckpointsActive();
        }
    }

    private void SetCheckpointsActive()
    {
        if (currentCheckpointIndex < checkpoints.Length)
        {
            checkpoints[currentCheckpointIndex].SetActive(true);
        }
    }
    
}