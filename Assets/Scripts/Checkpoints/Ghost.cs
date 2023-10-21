using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Ghost : ScriptableObject
{
    public bool isRecord;
    public bool isReplay;
    public float recordFrequancy;
    
    public List<float> timeSlap;
    public List<Vector3> position;
    public List<Vector3> rotation;

	public void ResetData()
    {
        timeSlap.Clear();
        position.Clear();
        rotation.Clear();
    }
    
}
