using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    public GameObject target; // The player's GameObject
    public GameObject boo;    // The object following the player
    public float moveSpeed = 5f; // Move speed
    public float rotationSpeed = 5f; // Speed of turning
    public float followDistance = 2f; // Distance to maintain behind the player
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target == null || boo == null)
        {
            Debug.LogWarning("Target or Boo is not assigned!");
            return;
        }

        // Check if target is within x bounds
        if (target.transform.position.x > -8.2f && target.transform.position.x < 8.4f)
        {
            // Rotate to look at the target
            Vector3 direction = target.transform.position - boo.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            boo.transform.rotation = Quaternion.Slerp(boo.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Calculate the desired position for boo, keeping a follow distance
            Vector3 offset = -target.transform.forward * followDistance; // Behind the player
            Vector3 desiredPosition = target.transform.position + offset;

            // Smoothly move boo towards the desired position
            Vector3 moveDirection = (desiredPosition - boo.transform.position).normalized * moveSpeed * Time.deltaTime;
            boo.transform.position += moveDirection;

            // Ensure boo does not overlap the player
            if (Vector3.Distance(boo.transform.position, target.transform.position) < followDistance)
            {
                boo.transform.position = target.transform.position + offset;
            }
        }
        else
        {
            // Optionally, stop boo's movement if target is out of bounds
            Debug.Log("Target is out of bounds. Boo will not follow.");
        }
    }
}
