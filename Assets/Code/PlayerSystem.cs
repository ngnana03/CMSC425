using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSystem : MonoBehaviour
{
    bool ItemDetect = false;
    private readonly Collider[] _colliders = new Collider[3];
    Collider col;
    float transparancy = 0;
    public  bool sleep = false;
    public Image imagetransparancy;
    public GameObject textsleepscreen;

    public bool item_1 = false;
    public bool item_2 = false;
    public bool item_3 = false;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(transparancy);
        if (ItemDetect && Input.GetKeyDown(KeyCode.F))
        {
            var interactionterminal = col.GetComponent<Interactionterminal>();
            interactionterminal.Interactwithitem(this);
        }



        if (sleep == true & transparancy < 255)
        {
            transparancy = transparancy + Time.deltaTime * 100;
        }
        if (transparancy > 255)
        {
            transparancy = 255;
        }


        if (sleep == false & transparancy > 0)
        {
            transparancy = transparancy - Time.deltaTime * 100;
        }
        if (transparancy <= 0)
        {
            transparancy = 0;
            textsleepscreen.SetActive(false);
        }

        imagetransparancy.GetComponent<Image>().color = new Color32(0, 0, 0, (byte) ((int)(transparancy % 256)));

    }

    // Change it to player collider instead of boo collider
    private void OnTriggerEnter(Collider other)
    {

        ItemDetect = true;
        
        col = other;
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        ItemDetect = false;

    }
}

