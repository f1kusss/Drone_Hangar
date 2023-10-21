using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float pointsTime = 0f;
    private bool isRunningPoints = false;
    private bool isRunning = false;
    public float bestTime = 0f;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }

        if (isRunningPoints)
        {
            pointsTime += Time.deltaTime;
        }

        Debug.Log("Point Time: " + pointsTime.ToString("F2") + "seconds");

        // Отображение времени
        Debug.Log("Elapsed Time: " + elapsedTime.ToString("F2") + " seconds");
    }

    // Начать отсчет времени
    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StratPointsTime()
    {
        isRunningPoints = true;
    }

    public void StopPointsTime()
    {
        isRunningPoints = false;
    }

    public void ResetPointsTime()
    {
        pointsTime = 0;
    }

    // Остановить отсчет времени
    public void StopStopwatch()
    {
        isRunning = false;
    }

    // Сбросить секундомер
    public void ResetStopwatch()
    {
        if (elapsedTime < bestTime && bestTime != 0f)
        {
            bestTime = elapsedTime;
        }
        else if (bestTime == 0f)
        {
            bestTime = elapsedTime;
        }

        Debug.Log($"<color=green>Best Time</color> {bestTime}");
        elapsedTime = 0f;
    }
}