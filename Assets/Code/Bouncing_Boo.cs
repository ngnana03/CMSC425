using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bouncing_Boo : MonoBehaviour
{
    public float Bounce_height = 1;
    public float Bounce_duration = 2;
    public float height_from_ground = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, Bounce_height * (float)Math.Cos(Time.time/ Bounce_duration) + height_from_ground, 0);
    }
}
