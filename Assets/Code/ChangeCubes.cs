using UnityEngine;

public class ChangeCubes : MonoBehaviour
{
    private BoxCollider greenCubeCollider;
    private BoxCollider redCubeCollider;
    private Collider playerCollider;

    public Vector3 startingPosition; // The original position to reset the player to
    public float resetHeight = -10f; // The y-coordinate below which the player will be reset
    private Rigidbody rb;
    private Renderer greenRenderer;
    private Renderer redRenderer;

    //For disabling and enabling cubes
    public Material emptyMaterial; // Drag the new material into this field in the Inspector
    public Material fillMaterial;

    //For sliding effect on player
    public float slideForce = 5f;         // Force applied to make the character slide
    public float slopeThreshold = 0.5f;   // Minimum slope angle to start sliding
    private bool isSliding;

    void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        // Get the material and original color of the object

        if (CompareTag("GreenCubePlatform"))
        {
            // Get the Renderer component if this is the cube
            greenRenderer = GetComponent<Renderer>();
            greenCubeCollider = GetComponent<BoxCollider>();
            //Debug.Log("green cube set");
        }

        if (CompareTag("RedCubePlatform"))
        {
            // Get the Renderer component if this is the cube
            redRenderer = GetComponent<Renderer>();
            redCubeCollider = GetComponent<BoxCollider>();

            Material[] ms = redRenderer.sharedMaterials;
            ms[1] = emptyMaterial;
            redRenderer.sharedMaterials = ms;

            //Debug.Log("red cube set");

        }

        //if (CompareTag("Player"))
        //{
        //    playerCollider = GetComponent<Collider>();
        //}
        //if (objectCollider != null)
        //{
        //    Debug.Log("Collider found: " + objectCollider);
        //}
        //else
        //{
        //    Debug.LogWarning("No Collider attached to this GameObject.");
        //}
    }

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeCubeState(greenCubeCollider, greenRenderer);
            changeCubeState(redCubeCollider, redRenderer);
        }

        

        // Check if the character is on a slope
        //isSliding = OnSlope() && !IsGrounded();

        //// Apply sliding force if on a slope
        //if (isSliding)
        //{
        //    Vector3 slopeDirection = GetSlopeDirection();
        //    rb.AddForce(slopeDirection * slideForce, ForceMode.Acceleration);
        //}
    }

    // Method to reset the player's position
    void ResetPosition()
    {
        transform.position = startingPosition;
        if (rb != null)
        {
            //Debug.Log("Player reset to starting position");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }

    bool OnSlope()
    {
        // Raycast down to check the slope angle
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.5f))
        {
            // Get the slope angle using the normal
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            return slopeAngle > slopeThreshold;
        }
        return false;
    }

    Vector3 GetSlopeDirection()
    {
        // Cast a ray to get the surface normal
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.5f))
        {
            // Calculate the slide direction based on the slope's normal
            return Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized;
        }
        return Vector3.zero;
    }

    bool IsGrounded()
    {
        // Basic ground check to prevent sliding when grounded on a flat surface
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void changeCubeState(Collider col, Renderer rend)
    {
        if (col != null && rend != null)
        {
            bool isEnabled = !col.enabled;
            col.enabled = isEnabled;
            Material[] ms = rend.sharedMaterials;

            if (isEnabled)
            {
                ms[1] = fillMaterial;
            }
            else
            {
                ms[1] = emptyMaterial;
            }

            rend.sharedMaterials = ms;
        }
    }
}
