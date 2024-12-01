using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private bool playerInRange = false;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ShowMessages());
        }
    }

    private IEnumerator ShowMessages()
    {
        textMeshPro.text = "On the dusty floor lies a single rose....";
        yield return new WaitForSeconds(4f);
        textMeshPro.text = "The stem points toward a painting on the wall—-a figure with bandages over their eyes, as if they’re staring directly at the flower.";
        yield return new WaitForSeconds(5f);
        textMeshPro.text = "Boo: Roses were Joe's mom's favorite flower....";
        yield return new WaitForSeconds(4f);
        textMeshPro.text = "but when he gave her one, it died the moment it saw her....";
        yield return new WaitForSeconds(4f);
        textMeshPro.text = "because even flowers can’t handle that level of beauty!";
    }
}
