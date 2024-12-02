using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bouncing_Boo : MonoBehaviour
{
    public float Bounce_height = 1;
    public float Bounce_duration = 2;
    public float height_from_ground = 0;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = (timer + Time.deltaTime) % (2 * Mathf.PI);
        // this is how the boo bounces, it is based on time 
        transform.position = new Vector3(transform.position.x, Bounce_height * (float)Math.Cos(Time.time/ Bounce_duration) + height_from_ground, transform.position.z);
    }
}
