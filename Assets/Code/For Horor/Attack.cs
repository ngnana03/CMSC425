using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private void Start()
    {
        textMeshPro.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trigger
        if (other.CompareTag("Player"))
        {
            EntityFollow.attack = true;
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Bob: JOE STOP!!";
        }
    }

}
