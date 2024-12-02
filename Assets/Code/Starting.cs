using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Starting : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Assign this in the Inspector

    private void Start()
    {
        StartCoroutine(ShowMessages());
    }

    private IEnumerator ShowMessages()
    {
        PauseMenu.isPaused= true; //Stops the player movement 
        textMeshPro.text = "Boo: Hey, who turned off the lights! I think you should look around and see if there's any clues.";
        yield return new WaitForSeconds(6f);
        textMeshPro.gameObject.SetActive(false); //deactivates the text
        PauseMenu.isPaused = false; //resumes the player movement
    }
}
