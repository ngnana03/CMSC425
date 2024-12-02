using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartDialogue : MonoBehaviour, Interactionterminal
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;
    public GameObject box;      // Dialogue Panel
    private int index;
    private AssetBundle bundle;
   // static PlayerMovement pmove;
    public GameObject tutorial;

    public bool Interactwithitem(PlayerSystem other)
    {
        tutorial.SetActive(false);
        box.SetActive(true);
        ActualStart();
       // pmove = other.GetComponent<PlayerMovement>();

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];
            }
        }
    }

    void ActualStart()
    {

        textcomponent.text = string.Empty;
        StartDialogue1();
    }

    void StartDialogue1()
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
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {

            // bundle = AssetBundle.LoadFromFile("Assets/Scenes");
            box.SetActive(false);

        }
    }
}
