using UnityEngine;
using UnityEngine.SceneManagement;

//This script activates the win screen when the player collects all the objects
public class Win : MonoBehaviour
{
    //Canvas object reference
    public GameObject winCanvas;
    // Name of the scene to return to
    public string menuSceneName = "Title";

    // win audio effect, assigned in the inspector
    public AudioClip winSound;
    private AudioSource audioSource;

    // player reference, assigned in inspector
    public GameObject player;
    private CharacterController playerController;

    //background music audio source
    private AudioSource backgroundMusicSource;

    public void WinScreen()
    {
        //find the background music and stop it
        GameObject backgroundMusic = GameObject.Find("BackgroundMusic");
        backgroundMusicSource = backgroundMusic.GetComponent<AudioSource>();
        backgroundMusicSource.Stop();

        //activate the game over screen
        winCanvas.SetActive(true);

        //Disable camera movement
        playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;

        //play sound
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(winSound);

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
