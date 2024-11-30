using UnityEngine;

//This scripts defines the behavior of the spin attack available to the player, pressing enter allows player to double jump and destroy walls
public class HoveringSphere : MonoBehaviour
{
    // Reference to the player object, assigned in inspector
    public Transform player;
    // Distance of the sphere in front of the player
    public float distanceInFront = 2.0f;
    // Height of the sphere
    public float height = 1.0f;
    // Speed at which the sphere follows the player
    public float followSpeed = 5.0f; 

    // Duration of the spin attack
    public float spinDuration = 1f;
    // Rotation speed in degrees per second
    public float spinSpeed = 360f;
    //Is the character currently spinning
    private bool isSpinning = false;
    //Current time of spin
    private float spinTimer = 0f;

    // Effect that appears when the sphere hits a wall, assigne in inspector
    public GameObject particleEffect; 

    void Update()
    {
        // Position of sphere
        Vector3 targetPosition = player.position + player.forward * distanceInFront + Vector3.up * height;

        // Check for spin attack input
        if (Input.GetMouseButtonDown(0) && !isSpinning)
        {
            StartSpin();
        }

        
        if (isSpinning)
        {
            UpdateSpin();
        }
        else
        {
            //Follow player
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    void StartSpin()
    {
        isSpinning = true;
        spinTimer = spinDuration;
    }

    void UpdateSpin()
    {
        //rotate sphere around the player
        transform.RotateAround(player.position, Vector3.up, spinSpeed * Time.deltaTime);

        // update timer
        spinTimer -= Time.deltaTime;
        if (spinTimer <= 0f)
        {
            EndSpin();
        }
    }

    void EndSpin()
    {
        isSpinning = false;
        spinTimer = 0f;
    }

    void OnTriggerStay(Collider col)
    {
        // Check if the spin attack hits a wall
        if (isSpinning && col.CompareTag("DestructibleWall"))
        {
            //create particle effect
            Instantiate(particleEffect, col.transform.position, Quaternion.identity);
            //destroy wall
            Destroy(col.gameObject); 
        }
    }
}
