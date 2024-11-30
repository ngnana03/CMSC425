using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creaking : MonoBehaviour
{
    public AudioSource audioSource;
    public float cooldownTime = 10f; 

    private bool canPlay = true;

    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player") && canPlay)
        {
            if (audioSource != null)
            {
                audioSource.Play();
                StartCoroutine(Cooldown());
            }
        }
    }

    private System.Collections.IEnumerator Cooldown()
    {
        canPlay = false;
        yield return new WaitForSeconds(cooldownTime);
        canPlay = true;
    }
}
