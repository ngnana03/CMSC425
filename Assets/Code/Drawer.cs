using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//allows for interaction with the drawer in the left first room
public class Drawer : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Assign this in the Inspector
    private bool playerInRange = false;
    private bool playing = false;

    private void Start()
    {
        textMeshPro.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerInRange = true;
            textMeshPro.text = "Press F to look in drawer";
            textMeshPro.gameObject.SetActive(true); // Ensure text is visible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            textMeshPro.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !(playing))
        {
            playing = true;
            StartCoroutine(ShowMessages());
        }
    }

    private IEnumerator ShowMessages()
    {
        PauseMenu.isPaused = true;
        textMeshPro.text = "Inside the drawer, you find an old family photo....";
        yield return new WaitForSeconds(6f); // Wait for 5 seconds
        textMeshPro.text = "Their faces have been violently scratched out, leaving jagged tears where their features should be. Despite the damage, it feels like their eyeless silhouettes are still watching you.....";
        yield return new WaitForSeconds(8f); // Wait for 5 seconds
        textMeshPro.text = "Boo: Oh ya! I remember Joe showing me them!";
        yield return new WaitForSeconds(6f); // Wait for 5 seconds
        textMeshPro.text = "Boo: Hahahahah .... good times.";
        yield return new WaitForSeconds(6f);
        PauseMenu.isPaused = false;
        playing = false;
    }
}
