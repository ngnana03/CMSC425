using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//https://youtu.be/-GWjA6dixV4?si=wy6SxbeA8Cv0xKbW this was used for this code
public class PlayGame : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void playGame()
    {
        SceneManager.LoadScene("startscene");
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }
}
