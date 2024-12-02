using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class datingScene : MonoBehaviour
{
     public string newSceneName; // The name of the scene to load when interacting with this object

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            SceneManager.LoadScene(newSceneName); // Load the new scene
        }
    }
}
