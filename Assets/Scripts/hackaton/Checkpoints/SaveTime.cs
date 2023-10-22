using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveTime : ScriptableObject
{
	public float pointsTime;
	public float elapsedTime;
	public float bestTime;

	public void ResetData()
	{
		pointsTime = 0f;
		elapsedTime = 0f;
	}

}
