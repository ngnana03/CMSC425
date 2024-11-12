using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public Image box;
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;

    private int index;


    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialogue();
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index])
            {
                NextLine();
            } else
            {
                StopAllCoroutines();   
                textcomponent.text = lines[index];
            }
        }
    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Types each char 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length-1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine (TypeLine());
        } else
        {
            gameObject.SetActive(false);
        }
    }
}
