using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCubeScene : MonoBehaviour
{
    public Vector3 startingPosition; // The original position to reset the player to
    public float resetHeight = -10f; // The y-coordinate below which the player will be reset
    public Material emptyMaterial;
    public Material fillMaterial;

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float slopeGravity = 1f; // Force to slide down slopes
    public float maxSlopeAngle = 45f; // Maximum angle to stand on without sliding
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private int doubleJumpCount;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    private bool canMove = true;

    private bool isSliding;
    private Vector3 slopeSlideVelocity;

    void Start()
    {
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
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (characterController.enabled)
        {
            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (characterController.isGrounded)
            {
                Debug.Log("is Grounded:");
                // Apply sliding force if on a steep slope
                doubleJumpCount = 0;
                if (OnSteepSlope(out Vector3 slopeDirection))
                {
                    moveDirection = slopeDirection * slopeGravity;
                    Debug.Log("moveDirec:");
                    Debug.Log(moveDirection);
                }

                
            }
            else
            {
                if (!characterController.isGrounded && Input.GetKeyDown(KeyCode.Return))
                {
                    doubleJumpCount++;
                    if (doubleJumpCount <= 1)
                    {
                        moveDirection.y = 0f;
                    }
                }
                Debug.Log("not Grounded:");
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            // Camera movement
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            // Reset position if player falls below resetHeight
            if (transform.position.y < resetHeight)
            {
                ResetPlayer();
                ResetCubes();
            }
        }        
    }

    private bool OnSteepSlope(out Vector3 slopeDirection)
    {
        slopeDirection = Vector3.zero;

        // Set a suitable distance for the raycast
        float rayDistance = characterController.height / 2 + 1f;

        // Offset the raycast origin slightly upwards to ensure accurate detection
        Vector3 rayOrigin = transform.position + Vector3.up * (characterController.height / 2);

        // Cast a ray downward from the player position to detect the slope
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, 5f))
        {
            // Calculate the slope angle
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            
            // Check if the slope angle is greater than the maximum allowed angle
            if (slopeAngle > characterController.slopeLimit)
            {
                // Calculate the sliding direction along the slope
                slopeDirection = Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized;
                return true;
            }
        }
        return false; // Not on a steep slope
    }

    //private void OnSteepSlope()
    //{
    //    //Vector3 slopeDirection = Vector3.zero;
    //    Vector3 velocity = Vector3.zero;

    //    // Cast a ray downward from the player position to detect the slope
    //    if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, 5f))
    //    {
    //        // Calculate the slope angle
    //        //float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

    //        // Check if the slope angle is greater than the maximum allowed angle
    //        //if (slopeAngle > characterController.slopeLimit)
    //        //{
    //            // Calculate the sliding direction along the slope
    //            Vector3 slopeDirection = Vector3.ProjectOnPlane(Vector3.down, hit.normal);
    //            velocity += slopeDirection * Vector3.Dot(Vector3.down, slopeDirection) * gravity * slopeGravity * Time.deltaTime;
                
    //        //}
    //    }
    //    velocity += moveDirection;
    //    velocity *= 0.95f;   // basic friction


    //    characterController.Move(velocity * Time.deltaTime);
    //}


    private void ResetPlayer()
    {
        // Reset the player's position
        transform.position = startingPosition;

        // Reset other properties (like velocity) if needed
        moveDirection = Vector3.zero;
    }

    private void ResetCubes()
    {
        // Find all GameObjects with the "ResettableCube" tag
        GameObject[] greenCubes = GameObject.FindGameObjectsWithTag("GreenCubePlatform");
        GameObject[] redCubes = GameObject.FindGameObjectsWithTag("RedCubePlatform");

        // Enable each cube
        foreach (GameObject cube in greenCubes)
        {
            Collider col = cube.GetComponent<BoxCollider>();
            Renderer rend = cube.GetComponent<Renderer>();
            if(col != null && col.enabled == false)
            {
                changeCubeState(col, rend);
            }
        }

        foreach (GameObject cube in redCubes)
        {
            Collider col = cube.GetComponent<BoxCollider>();
            Renderer rend = cube.GetComponent<Renderer>();
            if (col != null && col.enabled == true)
            {
                changeCubeState(col, rend);
            }
        }

        Debug.Log("All cubes have been re-enabled.");
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

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
//    public Vector3 startingPosition; // The original position to reset the player to
//    public float resetHeight = -10f; // The y-coordinate below which the player will be reset
//    private Rigidbody rb;
//    public Material emptyMaterial; // Drag the new material into this field in the Inspector
//    public Material fillMaterial;

//    public Camera playerCamera;
//    public float walkSpeed = 6f;
//    public float runSpeed = 12f;
//    public float jumpPower = 7f;
//    public float gravity = 10f;
//    public float lookSpeed = 2f;
//    public float lookXLimit = 45f;
//    public float defaultHeight = 2f;
//    public float crouchHeight = 1f;
//    public float crouchSpeed = 3f;

//    private Vector3 moveDirection = Vector3.zero;
//    private float rotationX = 0;
//    private CharacterController characterController;

//    private bool canMove = true;

//    public float moveSpeed = 5f;
//    public float slideForce = 5f; // Force applied for sliding
//    public float slopeLimit = 45f; // Max angle before sliding begins

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        startingPosition = transform.position;

//        characterController = GetComponent<CharacterController>();
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//    }

//    void Update()
//    {
//        Vector3 forward = transform.TransformDirection(Vector3.forward);
//        Vector3 right = transform.TransformDirection(Vector3.right);

//        bool isRunning = Input.GetKey(KeyCode.LeftShift);
//        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
//        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
//        float movementDirectionY = moveDirection.y;
//        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

//        if (characterController.enabled)
//        {
//            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
//            {
//                moveDirection.y = jumpPower;
//            }
//            else
//            {
//                moveDirection.y = movementDirectionY;
//            }

//            if (!characterController.isGrounded)
//            {
//                moveDirection.y -= gravity * Time.deltaTime;
//            }

//            if (Input.GetKey(KeyCode.R) && canMove)
//            {
//                characterController.height = crouchHeight;
//                walkSpeed = crouchSpeed;
//                runSpeed = crouchSpeed;

//            }
//            else
//            {
//                characterController.height = defaultHeight;
//                walkSpeed = 6f;
//                runSpeed = 12f;
//            }

//            characterController.Move(moveDirection * Time.deltaTime);

//            if (canMove)
//            {
//                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
//                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
//                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
//                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
//            }

//            if (transform.position.y < resetHeight)
//            {
//                ResetPlayer();
//                ResetCubes();
//            }
//        }        
//    }

//    private void ResetPlayer()
//    {
//        // Reset the player's position
//        transform.position = startingPosition;

//        // Reset other properties (like velocity) if needed
        
//        if (rb != null)
//        {
//            rb.velocity = Vector3.zero;
//            rb.angularVelocity = Vector3.zero;
//        }
//    }

//    private void ResetCubes()
//    {
//        // Find all GameObjects with the "ResettableCube" tag
//        GameObject[] greenCubes = GameObject.FindGameObjectsWithTag("GreenCubePlatform");
//        GameObject[] redCubes = GameObject.FindGameObjectsWithTag("RedCubePlatform");


//        // Enable each cube
//        foreach (GameObject cube in greenCubes)
//        {
//            Collider col = cube.GetComponent<BoxCollider>();
//            Renderer rend = cube.GetComponent<Renderer>();
//            if(col != null && col.enabled == false)
//            {
//                changeCubeState(col, rend);
//            }
            
//        }

//        foreach (GameObject cube in redCubes)
//        {
//            Collider col = cube.GetComponent<BoxCollider>();
//            Renderer rend = cube.GetComponent<Renderer>();
//            if (col != null && col.enabled == true)
//            {
//                changeCubeState(col, rend);
//            }
//        }

//        Debug.Log("All cubes have been re-enabled.");
//    }

//    void changeCubeState(Collider col, Renderer rend)
//    {
//        if (col != null && rend != null)
//        {
//            bool isEnabled = !col.enabled;
//            col.enabled = isEnabled;
//            Material[] ms = rend.sharedMaterials;

//            if (isEnabled)
//            {
//                ms[1] = fillMaterial;
//            }
//            else
//            {
//                ms[1] = emptyMaterial;
//            }
//            rend.sharedMaterials = ms;
//        }
            

//            //Debug.Log("apreta ese culito");
//            //Debug.Log(cube.tag);
        
//    }
//}