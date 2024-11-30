using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityFollow : MonoBehaviour
{
    public GameObject target; // The enemy's target
    public GameObject boo; // The object that follows the target
    public float moveSpeed = 5f; // Move speed
    public float rotationSpeed = 5f; // Speed of turning
    private Rigidbody rb;
    public static bool canFollow;
    public static bool attack;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canFollow = false;
        attack= false;
    }

    void Update()
    { 
        if (attack == true)
        {
            moveSpeed = 20f;
            Vector3 moveDirection = boo.transform.forward * Time.deltaTime * moveSpeed;
            moveDirection.y = 0;
            boo.transform.position += moveDirection;
        }
        else if (canFollow == true)
        {
            Vector3 direction = target.transform.position - boo.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            boo.transform.rotation = Quaternion.Slerp(boo.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (attack == false && Mathf.Abs(transform.position.z - target.transform.position.z) > 20)
            {
                Vector3 moveDirection = boo.transform.forward * Time.deltaTime * moveSpeed;
                moveDirection.y = 0;
                boo.transform.position += moveDirection;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player"))
        {
            PauseMenu.died = true;
        }
    }
}
