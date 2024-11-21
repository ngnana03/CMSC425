using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float RotationSpeed = -10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(
            Vector3.forward * RotationSpeed * Time.deltaTime,
            Space.Self
        );
    }

    public void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    public void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
