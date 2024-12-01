using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class interactwith : MonoBehaviour, Interactionterminal
{
    public int speed = 2;
    public bool Interactwithitem(PlayerSystem other)
    {
        StartCoroutine(floating());
        return true; 
    }
    IEnumerator floating()
    {
        // This method is also called as a coroutine, so you
        // will need at least one yield statment in it somewhere.
        float t = 0;
        while (t < speed)
        {
            float deltatime = Time.deltaTime;

            t = t + deltatime;
            if (t > speed)
            {
                deltatime = Math.Abs(speed - (t - deltatime));
            }
            transform.position = transform.position + new Vector3(0, 2 / (speed), 0) * deltatime;
           
            yield return null;
        }
        t = 0;
        while (t < speed)
        {
            float deltatime = Time.deltaTime;

            t = t + deltatime;
            if (t > speed)
            {
                deltatime = Math.Abs(speed - (t - deltatime));
            }
            transform.position = transform.position - new Vector3(0, 2 / (speed), 0) * deltatime;

            yield return null;
        }
        yield return null;
    }
}
 