using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(Input.GetKeyDown(KeyCode.Escape) && !died)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            //ResumeGame();
            SceneManager.LoadScene("Title");
            ResumeGame();
        }
        if (died && Input.GetKeyDown(KeyCode.Space))
        {
            died = false;
            //ResumeGame();
            SceneManager.LoadScene("Title");
            ResumeGame();
        }
        if (died)
        {
            Died();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausemenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausemenu.SetActive(false);
    }

    public void Died()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }
}
