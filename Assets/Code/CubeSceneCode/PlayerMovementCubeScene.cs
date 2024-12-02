using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script moves the player object based on input
public class PlayerMovementCubeScene : MonoBehaviour
{
    // Original position of player in the scene
    public Vector3 startingPosition;
    //checkpoints
    public Vector3 checkpoint1;
    public Vector3 checkpoint2;
    public Vector3 checkpoint3;
    public float checkpoint1Boundary;
    public float checkpoint2Boundary;
    public float checkpoint3Boundary;

    // The y-coordinate that sets the fall limit of the player
    public float resetHeight = -10f;

    // LifeCounter reference, assigned in inspector
    public LifeCounter lives;

    // jumping audio effect, assigned in the inspector
    public AudioClip jumpSound;
    // falling audio effect, assigned in the inspector
    public AudioClip fallingSound;
    private AudioSource audioSource;

    // Player movement and camera variables
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    private float rotationX = 0;
    private int doubleJumpCount;
    private Vector3 moveDirection;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moveDirection = Vector3.zero;
        startingPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isGrounded = IsGrounded();

        float currentXSpeed;
        float currentYSpeed;

        //Calculate current speed of player depending on if run key is pressed or not, using GetAxis allows for more control and cluster buttons together
        //Horizontal reads A and D input. Verticla reads W and S input.
        if (isRunning && isGrounded)
        {
            currentXSpeed = runSpeed * Input.GetAxis("Vertical");
            currentYSpeed = runSpeed * Input.GetAxis("Horizontal");
        }
        else
        {
            currentXSpeed = walkSpeed * Input.GetAxis("Vertical");
            currentYSpeed = walkSpeed * Input.GetAxis("Horizontal");
        }

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * currentXSpeed) + (right * currentYSpeed);
        
        if (characterController.enabled)
        {
            /*
             * Main feature of the scene is that the cubes flip after the player jumps, this mechanic makes it so that players think before they jump,
             * instead of running to the end goal
             */
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                moveDirection.y = jumpPower;
                //play sound
                audioSource.PlayOneShot(jumpSound);
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (isGrounded)
            {
                //reset double jump if player is grounded
                doubleJumpCount = 0;                
            }
            else
            {
                //double jump if player is not grounded and return is pressed
                if (!isGrounded && Input.GetMouseButtonDown(0))
                {
                    //prevent multiple double jumps consecutively
                    doubleJumpCount++;
                    if (doubleJumpCount <= 1)
                    {
                        moveDirection.y = jumpPower;
                    }
                }
                
            }

            //apply gravity to player
            moveDirection.y -= gravity * Time.deltaTime;

            //cap gravity to -10 to avoid sudden drops
            if(moveDirection.y < -10f)
            {
                moveDirection.y = -10f;
            }

            //apply movement            
            characterController.Move(moveDirection * Time.deltaTime);

            // Reset position if player falls below resetHeight (y < -10) and decrease lives counter
            if (transform.position.y < resetHeight)
            {
                ResetPlayer();
                lives.LoseLife();
                //characterController.enabled = true;
            }

            //Camera movement
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }        
    }

    void ResetPlayer()
    {
        if (transform.position.x > checkpoint3Boundary)
        {
            transform.position = checkpoint3;
        }
        else if (transform.position.x > checkpoint2Boundary)
        {
            transform.position = checkpoint2;
        }
        else if (transform.position.x > checkpoint1Boundary)
        {
            transform.position = checkpoint1;
        }
        else
        {
            transform.position = startingPosition;
        }

        //play sound
        audioSource.PlayOneShot(fallingSound);

        // Reset velocity 
        moveDirection = Vector3.zero;
    }

    //Calculate whether player is grounded or not, tests the player object against other colliders at the bottom
    public bool IsGrounded()
    {
        float sphereRadius = 0.5f, maxDistance = 1f;
        Vector3 castDirection = Vector3.down;
        bool sphereCheck = Physics.SphereCast(transform.position, sphereRadius, castDirection, out RaycastHit hit, maxDistance);

        return sphereCheck;
    }

}
