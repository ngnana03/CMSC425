using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entitymotion : MonoBehaviour
{
    public Vector3 rotation;
    Transform start;
    public float rotationspeed = 1;
    public static bool canfollow;
    public static EntityFollow entity;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        start = transform;

        entity = GameObject.Find("Entity").GetComponent<EntityFollow>();
        canfollow = EntityFollow.canFollow;
    }

    // Update is called once per frame
    void Update()
    {
    canfollow = EntityFollow.canFollow;   
    if (canfollow) 
        {
        timer = (timer + (Time.deltaTime * rotationspeed))% (1.0f * Mathf.PI);

        transform.eulerAngles = new Vector3(
        start.eulerAngles.x + (rotation.x * Mathf.Sin(timer)),
        start.eulerAngles.y + (rotation.y * Mathf.Sin(timer)),
        start.eulerAngles.z + (rotation.z * Mathf.Sin(timer)));
        }

    }
}
