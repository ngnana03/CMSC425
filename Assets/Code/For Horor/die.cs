using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class die : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    //checks if the player comes into contact with the entity
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMeshProUGUI.gameObject.SetActive(false); //sets the text to non active
            PauseMenu.died = true; //makes died in PauseMenu true and activate Died()
        }
    }
}
