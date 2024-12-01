using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void playGame()
    {
        SceneManager.LoadScene("Dating");
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }
}
