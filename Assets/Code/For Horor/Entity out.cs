using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
//makes the wall disappear 
public class Entityout : MonoBehaviour
{
    public bool triggered;
    public GameObject wall;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && triggered == false)
        {
            wall.active = false; //deactivates the wall
            triggered = true; //make sure the script only runs oncce
            StartCoroutine(message()); //activates the text
        }
    }

    private IEnumerator message()
    {
        PauseMenu.isPaused = true; //pauses playermovement
        textMeshPro.gameObject.SetActive(true);
        textMeshPro.text = "*Something has opened....*";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Oh hey Joe! Didn't know you were still here!.....";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Why do you look so mad......";
        yield return new WaitForSeconds(6f);
        textMeshPro.text = "Boo: Hey I don't mean to scare you but I think we should just keep walking and not turn around anymore.";
        yield return new WaitForSeconds(6f);
        textMeshPro.gameObject.SetActive(false) ;
        PauseMenu.isPaused = false; //reactivates player movement 
    }
}
