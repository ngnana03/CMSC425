using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI textMeshProUGUI;
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

        if (PauseMenu.died == true)
        {
            textMeshProUGUI.gameObject.SetActive(false);
        }
    }
}
