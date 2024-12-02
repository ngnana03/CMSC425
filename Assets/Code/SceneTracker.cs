using TMPro;
using UnityEngine;

//This script creates a singleton, I used the following resource to learn about it: https://gamedevbeginner.com/singletons-in-unity-the-right-way/
//This script is used to track the completion of the different levels in the game, the object containg a counter that persists when loading different scenes
public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance { get; private set; }

    public int completeCount = 0; // Tracks the number of completed scenes
    public int totalScenesToComplete = 3; // Number of scenes needed to win
    private int completedScenes = 0;

    public bool isHorrorSceneComplete;
    public bool isAdventureSceneComplete;
    public bool isDatingSceneComplete;

    public GameObject popupPanel; // Assign in the Inspector
    public TextMeshProUGUI popupText; // Assign in the Inspector

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;
        }

        isHorrorSceneComplete = false;
        isAdventureSceneComplete = false;
        isDatingSceneComplete = false;

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist this object between scenes
    }

    public void CheckWinCondition()
    {
        if (isHorrorSceneComplete && isAdventureSceneComplete && isDatingSceneComplete)
        {
            ShowPopupMessage(); // Show the congratulatory message
        }

    }

    private void ShowPopupMessage()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true); // Enable the popup panel
            popupText.text = "Congratulations! You completed all scenes!"; // Set the message
        }
        else
        {
            Debug.LogError("PopupPanel is not assigned in the Inspector!");
        }
    }

    public void BackToTitle()
    {
        // Load the main menu scene (replace "MainMenu" with your scene name)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        this.ResetCompletedScenes();
    }

    public void ResetCompletedScenes()
    {
        completeCount = 0;
    }
}
