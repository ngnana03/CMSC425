using UnityEngine;

//This script allows to oscillate either the position or rotation of an object
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
