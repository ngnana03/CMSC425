using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityFoward : MonoBehaviour
{
    public MonoBehaviour scriptToPause; // Assign the script you want to pause in the Inspector
    public GameObject entity;
    public GameObject player;
    private IEnumerator PauseCoroutine(float seconds)
    {
        if (scriptToPause != null)
        {
            scriptToPause.enabled = false; // Disable the script
            yield return new WaitForSeconds(seconds); // Wait for the specified time
            scriptToPause.enabled = true; // Re-enable the script
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player"))
        {
            EntityFollow.canFollow = true;
            StartCoroutine(PauseCoroutine(5f));
            player.transform.rotation = Quaternion.LookRotation(entity.transform.position);

        }
    }

}
