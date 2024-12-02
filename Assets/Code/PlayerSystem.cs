using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSystem : MonoBehaviour
{
    public bool ItemDetect = false;
    private readonly Collider[] _colliders = new Collider[3];
    Collider col;
    float transparancy = 255;
    public  bool sleep = false;
    public Image imagetransparancy;
    public GameObject textsleepscreen;

    public bool item_1 = false;
    public bool item_2 = false;
    public bool item_3 = false;
    // Update is called once per frame
    void Update()
    {
        // it checks if an item is detected, if F is pressed, and if the item in view has an interactionterminal
        if (ItemDetect && Input.GetKeyDown(KeyCode.F)&&(col.GetComponent<Interactionterminal>() != null))
        {
            // interact with the interaction terminal
            var interactionterminal = col.GetComponent<Interactionterminal>();
            interactionterminal.Interactwithitem(this);
        }


        // when going to sleep, the screen becomes black 
        if (sleep == true & transparancy < 255)
        {
            transparancy = transparancy + Time.deltaTime * 100;
        }
        if (transparancy > 255)
        {
            transparancy = 255;
        }

        // when waking up, the screen becomes white 
        if (sleep == false & transparancy > 0)
        {
            transparancy = transparancy - Time.deltaTime * 100;
        }
        if (transparancy <= 0)
        {
            transparancy = 0;
        }
        //changing the sleeep screen. 
        imagetransparancy.GetComponent<Image>().color = new Color32(0, 0, 0, (byte) ((int)(transparancy % 256)));

    }

    // mark as an item being detected and chance col to that item. 
    private void OnTriggerEnter(Collider other)
    {

        ItemDetect = true;
        
        col = other;
    }

    private void OnTriggerExit(Collider other)
    {
        ItemDetect = false;
        col = null;
    }
}

