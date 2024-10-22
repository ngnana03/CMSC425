using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    bool ItemDetect = false;
    private readonly Collider[] _colliders = new Collider[3];
    Collider col;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ItemDetect);
        if (ItemDetect && Input.GetKeyDown(KeyCode.F))
        {
            var interactionterminal = col.GetComponent<Interactionterminal>();
            interactionterminal.Interactwithitem(this);
        }
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

