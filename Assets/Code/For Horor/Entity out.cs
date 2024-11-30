using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Entityout : MonoBehaviour
{
    public bool triggered;
    public GameObject wall;

    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && triggered == false)
        {
            wall.active = false;
            triggered = true;
        }
    }
}
