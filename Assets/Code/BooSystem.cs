using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooSystem : MonoBehaviour
{
    bool playerDetect = false;

    // Update is called once per frame
    void Update()
    {
        if (playerDetect && Input.GetKeyDown(KeyCode.F))
        {
            print("dialogue start");
        }
    }

    // Change it to player collider instead of boo collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            playerDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetect = false;
    }
}