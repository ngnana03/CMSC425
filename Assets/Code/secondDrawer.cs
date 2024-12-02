using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class secondDrawer : MonoBehaviour
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
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
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
        textMeshPro.text = "Inside the drawer, you find an old, tarnished locket with the name Joe engraved on it.";
        yield return new WaitForSeconds(6f); 
        textMeshPro.text = "Across the engraving is a deep, jagged scratch, as if someone tried to erase the name�or ensure it would never be forgotten.";
        yield return new WaitForSeconds(6f); 
        textMeshPro.text = "Boo: Ohhhhhh so thats where Joe put it!";
        yield return new WaitForSeconds(6f); 
        textMeshPro.text = "Boo: He's been going crazy looking for it!\n *You decide to put the locket in your pocket for safe keeping*";
        yield return new WaitForSeconds(6f);
        PauseMenu.isPaused = false;
        playing = false;
    }
}