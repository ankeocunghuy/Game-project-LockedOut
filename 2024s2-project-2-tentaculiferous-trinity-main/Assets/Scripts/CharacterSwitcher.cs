using UnityEngine;

public class CharacterControllerCustom : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    public Transform cameraTransform; // Reference to the camera transform
    private bool isGrounded;

    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Capture movement input from WASD keys
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        MoveRelativeToCamera();

        // Apply gravity adjustments if the player is not grounded
        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime;
        }
    }

    void MoveRelativeToCamera()
    {
        // Get the forward and right directions relative to the camera
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // Lock movement to the XZ plane (no Y-axis movement)

        Vector3 right = cameraTransform.right;
        right.y = 0; // Lock movement to the XZ plane (no Y-axis movement)

        // Calculate movement relative to camera orientation
        Vector3 desiredMovement = (forward * movementInput.z + right * movementInput.x).normalized * speed;

        // Apply movement to the rigidbody
        rb.velocity = new Vector3(desiredMovement.x, rb.velocity.y, desiredMovement.z);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
