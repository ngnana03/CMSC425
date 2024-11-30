using UnityEngine;
using UnityEngine.SceneManagement;

//This script activate the win screen when the player collects all the objects
public class Win : MonoBehaviour
{
    //Canvas object reference
    public GameObject winCanvas;
    // Name of the scene to return to
    public string menuSceneName = "House";

    public void WinScreen()
    {
        //activate the game over screen
        winCanvas.SetActive(true);

        //unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //pause game
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        //reload the current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnHome()
    {
        //return to home scene
        SceneManager.LoadScene(menuSceneName);
    }
}
