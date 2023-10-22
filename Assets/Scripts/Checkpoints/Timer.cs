using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public SaveTime saveTime;
    private bool isRunningPoints = false;
    private bool isRunning = false;

    public TextMeshProUGUI elapsedTimeTMPro;
    public TextMeshProUGUI bestTimeTMPro;
    public TextMeshProUGUI pointTimeTMPro;

    public GhostRecorder recorder;

	private void Awake()
	{
        recorder = FindObjectOfType<GhostRecorder>();
        saveTime.ResetData();
		//bestTimeTMPro.text = "Время лучшего круга: " + saveTime.bestTime.ToString("F2") + "секунд";
	}

	void Update()
    {
        if (isRunning)
        {
            saveTime.elapsedTime += Time.deltaTime;
        }

        if (isRunningPoints)
        {
            saveTime.pointsTime += Time.deltaTime;
        }

        // Debug.Log("Point Time: " + saveTime.pointsTime.ToString("F2") + "seconds");
        pointTimeTMPro.text = "Время между чекпоинтами: " + saveTime.pointsTime.ToString("F2") + "секунд";

		// Отображение времени
		// Debug.Log("Elapsed Time: " + saveTime.elapsedTime.ToString("F2") + " seconds");
		elapsedTimeTMPro.text = "Время круга: " + saveTime.elapsedTime.ToString("F2") + "секунд";
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
        saveTime.pointsTime = 0;
    }

    // Остановить отсчет времени
    public void StopStopwatch()
    {
        isRunning = false;
    }

    // Сбросить секундомер
    public void ResetStopwatch()
    {
        if (saveTime.elapsedTime < saveTime.bestTime)
        {
            recorder.RecordBest();
            saveTime.bestTime = saveTime.elapsedTime;
            
        }
        else if (saveTime.bestTime == 0f)
        {
            recorder.RecordBest();
            saveTime.bestTime = saveTime.elapsedTime;
        }

        // Debug.Log($"<color=green>Best Time</color> {saveTime.bestTime}");
		bestTimeTMPro.text = "Время лучшего круга: " + saveTime.bestTime.ToString("F2") + "секунд";
		saveTime.elapsedTime = 0f;
    }
}