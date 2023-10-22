using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{

    public pointsControle Controller;
    void Start()
    { 
        Controller = FindObjectOfType<pointsControle>();
        Debug.Log(Controller);
        if (Controller is null)
        {
            Debug.Log("<color=red>Add pointControle script</color>");
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("drone"))
        {
            Controller.NextPoint();
        }
    }
}
