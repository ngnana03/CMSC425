using UnityEngine;

/* This script allows to oscillate either the position or rotation of an object
 * The script will be attached to an empty object that will be the parent of the destructible walls, this makes it so that the modifications
 * to the transform values of the walls are not realtive to the global cordinate system, but relative to the parent object. I got this idea from the 
 * Unit 06 video from class
 */
public class ModifyTransform : MonoBehaviour
{
    //Dropdown options that can be assigned in inspector
    public enum Mode {Position, Rotation} 
    public Mode transformMode;

    //speed of oscillation
    public float speed = 1f;
    //Initial value of object
    private Vector3 startValue;
    //maximum value to oscillate towards
    public Vector3 targetValue; 

    void Start()
    {
        // save the initial transform values
        switch (transformMode)
        {
            case Mode.Position:
                startValue = transform.position;
                break;

            case Mode.Rotation:
                startValue = transform.eulerAngles;
                break;
        }
    }

    void Update()
    {
        // value that oscillates between 0 and 1
        float oscillationFactor = Mathf.PingPong(Time.time * speed, 1f);

        switch (transformMode)
        {
            case Mode.Position:
                transform.position = Vector3.Lerp(startValue, startValue + targetValue, oscillationFactor);
                break;

            case Mode.Rotation:
                // Calculate oscillation angle
                transform.eulerAngles = Vector3.Lerp(startValue, startValue + targetValue, oscillationFactor);
                break;
        }
    }
}
