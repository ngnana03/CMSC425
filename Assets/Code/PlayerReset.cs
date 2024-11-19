using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Vector3 startingPosition; // The original position to reset the player to
    public float resetHeight = -10f; // The y-coordinate below which the player will be reset
    private BoxCollider objectCollider;

    void Start()
    {
        // Set the starting position to the player's initial position
        startingPosition = transform.position;
        objectCollider = GetComponent<BoxCollider>();
        
    }

    void Update()
    {
        // Check if the player has fallen below the reset height
        if (transform.position.y < resetHeight)
        {
            ResetPosition();
            //objectCollider.enabled = !objectCollider.enabled;
        }
    }

    // Method to reset the player's position
    void ResetPosition()
    {
        transform.position = startingPosition;
        //Debug.Log("Player reset to starting position");
    }
}
