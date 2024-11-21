using UnityEngine;

public class SpinAttack : MonoBehaviour
{
    public GameObject spinObject; // Assign the rectangle in the Inspector
    public float spinDuration = 1.0f; // Duration of the spin attack
    public float spinSpeed = 360f; // Rotation speed in degrees per second
    public float jumpForce = 5.0f; // Jump force when spinning in the air
    public float gravity = -9.8f; // Gravity applied to the player
    public float doubleJump = 150f;

    private int doubleJumpCount;
    private CharacterController characterController;
    private bool isSpinning = false;
    private float spinTimer = 0f;
    private float verticalVelocity = 0f;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (spinObject == null)
        {
            Debug.LogError("Spin object (rectangle) not assigned!");
        }
    }

    void Update()
    {
        // Check for spin attack input
        if (Input.GetKeyDown(KeyCode.Return) && !isSpinning)
        {
            StartSpin();
        }

        // Update spin attack logic
        if (isSpinning)
        {
            UpdateSpin();
        }
        //else
        //{
        //    ApplyGravity();
        //}



        //if (!characterController.isGrounded && Input.GetKeyDown(KeyCode.Return))
        //{
            
        //    doubleJumpCount++;
        //    if(doubleJumpCount <= 1)
        //    {
        //        moveDirection.y = doubleJump;
        //        characterController.Move(moveDirection * Time.deltaTime);
        //    }

        //}

        //if(characterController.isGrounded)
        //{
        //    doubleJumpCount = 0;
        //}

        


        //// Move the player (even if it's just to apply gravity)
        //Vector3 move = new Vector3(0, verticalVelocity * Time.deltaTime, 0);
        //characterController.Move(move);
    }

    void StartSpin()
    {
        isSpinning = true;
        spinTimer = spinDuration;

        // Stop downward movement and apply upward force if not grounded
        if (!characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }

    void UpdateSpin()
    {
        // Rotate the spin object around the player
        if (spinObject != null)
        {
            spinObject.transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
        }

        // Apply upward force if in the air
        if (!characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity = 0f; // Ensure the player stays grounded
        }

        // Update spin timer
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

    void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = 0f; // Reset vertical velocity when grounded
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime; // Apply gravity
        }
    }
}
