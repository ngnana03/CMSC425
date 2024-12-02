using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cross : MonoBehaviour
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
            textMeshPro.text = "Press F to look at the cross";
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
        textMeshPro.text = "On the table rests an old, weathered cross...";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "its surface marred with deep scratches and burn marks...";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Around its base, the wood is stained dark, as if something had seeped into it over time.";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Despite the stillness of the room, it feels like the cross is waiting for something...or someone....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Joes mom always used to carry around that cross.";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: I swear it was the only thing keeping her from losing her temper...";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Seriously I'm not joking.....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: CROSS my heart! HAHAHHAHAHHA";
        yield return new WaitForSeconds(6f);
        PauseMenu.isPaused = false;
        playing= false;

    }
}
