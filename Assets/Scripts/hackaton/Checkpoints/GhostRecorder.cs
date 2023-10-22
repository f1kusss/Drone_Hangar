using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public Ghost ghost;
    public float timer;
    public float timeValue;
    public SaveTime saveTime;

    private void Awake()
    {
        if (ghost.isRecord)
        {
            ghost.ResetData();
            timeValue = 0;
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeValue += Time.deltaTime;
        if (ghost.isRecord & timer >= 1 / ghost.recordFrequancy)
        {
            ghost.timeSlap1.Add(timeValue);
            ghost.position1.Add(this.transform.position);
            ghost.rotation1.Add((this.transform.eulerAngles));
            timer = 0;
        }

        // if (saveTime.elapsedTime < saveTime.bestTime)
        // {
        //     RecordBest();
        // }
    }

    public void RecordBest()
    {
        ghost.ResetBestData();
        ghost.timeSlap2.AddRange(ghost.timeSlap1.ToArray());
        ghost.position2.AddRange(ghost.position1.ToArray());
        ghost.rotation2.AddRange(ghost.rotation1.ToArray());
    }
}