using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//tell the entity to attack the player and plays text
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
            EntityFollow.attack = true; //makes the entity run towards the player
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Bob: JOE STOP!!";
        }
    }

}
