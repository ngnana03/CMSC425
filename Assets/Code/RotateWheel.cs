using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public float RotationSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            Vector3.forward * RotationSpeed * Time.deltaTime,
            Space.Self
        );
    }
}
