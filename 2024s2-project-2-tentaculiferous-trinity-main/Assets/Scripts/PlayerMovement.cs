using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from ChatGPT, altered to fit purposes
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f; // The rate of acceleration
    [SerializeField] private float deceleration = 5f; // The rate of deceleration when no input is given
    [SerializeField] private float maxSpeed = 10f;    // The maximum speed the player can reach
    [SerializeField] private float jumpForce = 10f;   // The upward force applied when jumping
    [SerializeField] private float gravityMultiplier = 0.5f; // How fast the player falls down
    [SerializeField] private float rightingTorque = 10f; // Torque applied to right the object


    private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    private Vector3 movementInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // cameraTransform = Camera.main.transform; // Get the camera's transform
    }

    void Update()
    {
        // Get movement input from WASD keys
        float moveHorizontal = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        float moveVertical = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        movementInput = new Vector3(moveHorizontal, 0, moveVertical);
        // Normalize movement input to prevent faster diagonal movement
        if (movementInput.magnitude > 1)
            movementInput.Normalize();

        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        // Jump mechanic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {
        // Convert movement input to be relative to the camera's facing direction
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // Ensure movement is only in the xz plane
        Vector3 right = cameraTransform.right;
        right.y = 0; // Ensure movement is only in the xz plane

        // Apply movement input relative to the camera
        Vector3 desiredMovement = (forward * movementInput.z + right * movementInput.x).normalized * maxSpeed;
        
        // Apply acceleration to the player's movement
        if (movementInput.magnitude > 0)
        {
            // Accelerate towards the desired movement direction
            rb.velocity = Vector3.Lerp(rb.velocity, desiredMovement, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            // Decelerate when no input is given
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
        }

        // Apply a reduced gravity for a slower fall
        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.fixedDeltaTime;
        }

        // Apply torque to right the object when in the air
        if (!isGrounded)
        {
            
        }
        Vector3 desiredUp = Vector3.up;
        Vector3 currentUp = transform.up; 
        Vector3 rightingForce = Vector3.Cross(currentUp, desiredUp);
        rb.AddTorque(rightingForce * rightingTorque);
    }
}