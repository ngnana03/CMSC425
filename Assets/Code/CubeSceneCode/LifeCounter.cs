using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This script updates the lives counter when player falls off the map, ends game if lives run out
public class LifeCounter : MonoBehaviour
{
    //reference to text box
    public TMP_Text livesText;
    //number of lives available 
    private int lives = 5;
    //reference to gameover object 
    public GameOver gameOver;

    void Start()
    {
        UpdateLivesDisplay();
    }

    public void LoseLife()
    {
        //Decrease counter and update display
        lives--;
        UpdateLivesDisplay();

        //if lives run out, activate game over screen
        if (lives <= 0)
        {
            gameOver.GameOverScreen();
        }
    }

    //Updates counter display
    private void UpdateLivesDisplay()
    {
        livesText.text = "Lives: " + lives;
    }
}
