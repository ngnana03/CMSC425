using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class die : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMeshProUGUI.gameObject.SetActive(false);
            PauseMenu.died = true;
        }
    }
}
