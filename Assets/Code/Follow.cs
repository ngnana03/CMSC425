using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);


        //move towards the player
        if ((transform.position.x - target.transform.position.x > 2 || transform.position.x - target.transform.position.x < -2 )&& (transform.position.z - target.transform.position.z > 2 || transform.position.z - target.transform.position.z < -2))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

}
