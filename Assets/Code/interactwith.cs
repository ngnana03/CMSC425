using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class interactwith : MonoBehaviour, Interactionterminal
{
    bool isfloating = false;
    public int speed = 2;
    public bool Interactwithitem(PlayerSystem other)
    {
        StartCoroutine(floating());
        //yield return new WaitForSeconds(4);
        return true; 
    }
    IEnumerator floating()
    {
        yield return move();
        yield return new WaitForSeconds(4);
    }


    IEnumerator move()
    {
        // This method is also called as a coroutine, so you
        // will need at least one yield statment in it somewhere.
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
 