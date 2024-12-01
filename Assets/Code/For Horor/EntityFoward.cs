using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EntityFoward : MonoBehaviour
{
    public MonoBehaviour scriptToPause; // Assign the script you want to pause in the Inspector
    public GameObject entity;
    public GameObject player;
    public static bool played;
    public TextMeshProUGUI textMeshPro;

    public void Start()
    {
        played = false;
    }
    private IEnumerator PauseCoroutine(float seconds)
    {
        if (scriptToPause != null)
        {
            scriptToPause.enabled = false; // Disable the script
            yield return new WaitForSeconds(seconds); // Wait for the specified time
            scriptToPause.enabled = true; // Re-enable the script
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Boo: Walk back slowly. Don't take your eyes off it.";
            yield return new WaitForSeconds(4f);
            textMeshPro.text = "Boo: Keep going......";
            yield return new WaitForSeconds(3f);
            textMeshPro.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player") && played == false)
        {
            EntityFollow.canFollow = true;
            StartCoroutine(PauseCoroutine(5f));
            player.transform.rotation = Quaternion.LookRotation(entity.transform.position);
            played = true;
        }
    }

}
