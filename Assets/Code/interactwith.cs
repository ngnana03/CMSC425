using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class interactwith : MonoBehaviour, Interactionterminal
{
    bool isfloating = false;
    // give input with how fast the bed moves 
    public int speed = 2;
    public bool Interactwithitem(PlayerSystem other)
    {
        StartCoroutine(floating());
        //yield return new WaitForSeconds(4);
        return true; 
    }
    IEnumerator floating()
    {
        // do the move, and do the wait for seconds so you cant do it mutple times at the same time. 
        yield return move();
        yield return new WaitForSeconds(2*2);
    }


    IEnumerator move()
    {
        // this is used to make the bed flaot 
        if (isfloating)
        {
            yield break;
        }
        isfloating = true;
        float t = 0;
        while (t < speed)
        {
            float deltatime = Time.deltaTime;

            t = t + deltatime;
            if (t > speed)
            {
                deltatime = Math.Abs(speed - (t - deltatime));
            }
            // use the positision to float the bed.
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

        isfloating = false;
        yield return null;
    }
}
 