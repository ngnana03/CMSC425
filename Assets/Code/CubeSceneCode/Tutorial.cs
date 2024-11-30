using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    //time the text will be visible to the player
    public float displayDuration = 5f; 

    private void Start()
    {
        //deactivate the text after the display duration
        Invoke("HideText", displayDuration);
    }

    private void HideText()
    {
        instructionText.gameObject.SetActive(false);
    }
}
