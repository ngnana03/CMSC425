using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//This script updates the collectible counter when player collects the collectibles, ends game if win condition is met
public class CollectibleCounter : MonoBehaviour
{
    //reference to text box
    public TMP_Text collectibleCountText;
    //number of collectibles needed to win
    public int winCount = 15;
    // reference to the win screen object
    public Win winScreen;
    //name of the scene to return to
    public string menuSceneName = "House"; 
    
    private int collectibleCount = 0;

    void Start()
    {
        UpdateCollectible();
    }

    public void AddCollectible()
    {
        collectibleCount++;
        UpdateCollectible();

        //if count is 15, show win screen
        if (collectibleCount >= winCount)
        {
            winScreen.WinScreen();
        }
    }

    private void UpdateCollectible()
    {
        //update current count
        collectibleCountText.text = $"Collectibles: {collectibleCount}/{winCount}";
    }
}
