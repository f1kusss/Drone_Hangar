using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Ghost : ScriptableObject
{
    public bool isRecord;
    public float recordFrequancy;
    
    public List<float> timeSlap1;
    public List<Vector3> position1;
    public List<Vector3> rotation1;
    public List<float> timeSlap2;
    public List<Vector3> position2;
    public List<Vector3> rotation2;

	public void ResetData()
    {
        timeSlap1.Clear();
        position1.Clear();
        rotation1.Clear();
       
        
    }

    public void ResetBestData()
    {
        timeSlap2.Clear();
        position2.Clear();
        rotation2.Clear();

    }
    
}
