using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//https://youtu.be/9dYDBomQpBQ?si=GprVtBMXHe-vdu2j this was used for this code
public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject deathScreen;
    public static bool isPaused;
    public static bool died;

    void Start()
    {
        pausemenu.SetActive(false);
        deathScreen.SetActive(false);
        died = false;
    }

    void Update()
    {
        //checks for esc input
        if(Input.GetKeyDown(KeyCode.Escape) && !died)
        {
            //if the screen is paused it will resume the game
            if(isPaused)
            {
                ResumeGame();
            }
            else //if the game isnt paused it will resume the game
            {
                PauseGame();
            }
        }
        //checks for spacebar input when scene is paused
        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            SceneManager.LoadScene("startscene");
            ResumeGame();
        }
        //checks for spacebar input when died screen is activated 
        if (died && Input.GetKeyDown(KeyCode.Space))
        {
            died = false;
            //set flag,scene was completed scenes 
            SceneTracker.Instance.isHorrorSceneComplete= true;
            //congratulate player and return to title screen if player completed all scenes
            if(SceneTracker.Instance.CheckWinCondition())
            {
                SceneManager.LoadScene("Win Scene");
            }
            else
            {
                SceneManager.LoadScene("startscene");
            }
            ResumeGame();
        }
        //if the died vaiable is true it will activate the died method
        if (died)
        {
            Died();
        }
    }

    //pauses the scene
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausemenu.SetActive(true);
    }

    //resumes the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausemenu.SetActive(false);
    }

    //activates the death screen
    public void Died()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }
}
