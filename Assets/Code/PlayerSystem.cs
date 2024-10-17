using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    bool ItemDetect = false;
    private readonly Collider[] _colliders = new Collider[3];

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ItemDetect);
        if (ItemDetect && Input.GetKeyDown(KeyCode.F))
        {

        }
    }

    // Change it to player collider instead of boo collider
    private void OnTriggerEnter(Collider other)
    {

        ItemDetect = true;
        var interactionterminal = other.GetComponent<Interactionterminal>();
            
        interactionterminal.Interactwithitem(this);
        
    }

    private void OnTriggerExit(Collider other)
    {
        ItemDetect = false;

    }
}

