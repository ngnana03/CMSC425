using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityFoward : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player"))
        {
            EntityFollow.canFollow = true;
        }
    }

}
