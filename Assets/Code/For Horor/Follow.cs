using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    public GameObject target; // The enemy's target
    public GameObject boo; // The object that follows the target
    public float moveSpeed = 5f; // Move speed
    public float rotationSpeed = 5f; // Speed of turning
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

        // Rotate to look at the player
        Vector3 direction = target.transform.position - boo.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        boo.transform.rotation = Quaternion.Slerp(boo.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player if within x bounds
        if (target.transform.position.x > -8.2f && target.transform.position.x < 8.4f)
        {
            if ( Mathf.Abs(transform.position.z - target.transform.position.z) > 5)
            {
                Vector3 moveDirection = boo.transform.forward * Time.deltaTime * moveSpeed;
                boo.transform.position += moveDirection;
            }
        }
    }
}
