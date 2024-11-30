using UnityEngine;
using UnityEngine.SceneManagement;

//This script shows the game over screen when lives run out
public class GameOver : MonoBehaviour
{
    //Canvas object reference
    public GameObject gameOverCanvas;

    public void GameOverScreen()
    {
        //activate the game over screen
        gameOverCanvas.SetActive(true);

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

    public void Quit()
    {
        //quit game
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
