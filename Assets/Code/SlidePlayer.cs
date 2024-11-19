using UnityEngine;

public class SlippyController : MonoBehaviour
{
    CharacterController cc;
    Vector3 velocity;
    RaycastHit hit;

    float gravity = 20f;
    float slippy = 10f; // How slippery are the slopes?

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (cc.isGrounded)
        {
            // slide down slopes:
            if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 5f)) // raycast to get the hit normal
            {
                Vector3 dir = Vector3.ProjectOnPlane(Vector3.down, hit.normal); // slope direction
                velocity += dir * Vector3.Dot(Vector3.down, dir) * gravity * slippy * Time.deltaTime;
            }
            velocity += moveDirection;
            velocity *= 0.95f;   // basic friction
        }
        else
            velocity.y -= gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }
}