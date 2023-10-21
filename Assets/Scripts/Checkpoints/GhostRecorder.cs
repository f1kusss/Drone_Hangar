using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public Ghost ghost;
    public float timer;
    public float timeValue;

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
        timer += Time.unscaledDeltaTime;
        timeValue += Time.unscaledDeltaTime;
        if (ghost.isRecord & timer >= 1 / ghost.recordFrequancy)
        {
            ghost.timeSlap.Add(timeValue);
            ghost.position.Add(this.transform.position);
            ghost.rotation.Add((this.transform.eulerAngles));
            timer = 0;
        }
    }
}
