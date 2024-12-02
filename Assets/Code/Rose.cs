using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
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
            textMeshPro.text = "Press F to look at the rose";
            textMeshPro.gameObject.SetActive(true); 
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
        textMeshPro.text = "On the dusty floor lies a single rose....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "The stem points toward a painting on the wall. The painting shows a figure with bandages over their eyes. ";
        yield return new WaitForSeconds(6f);
        textMeshPro.text =  "Even though the figures face is covered, you cant help but feel as if they�re staring directly at the flower.";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Roses were Joe's mom's favorite flower....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: but when he gave her one, it died the moment it saw her....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: because even flowers can�t handle that level of beauty!";
        yield return new WaitForSeconds(6f);
        PauseMenu.isPaused = false;
        playing = false;

    }
}
