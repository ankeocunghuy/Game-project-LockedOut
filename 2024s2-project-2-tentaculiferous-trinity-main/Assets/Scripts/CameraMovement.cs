using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from ChatGPT with modifications

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;  // The camera's transform that controls movement
    [SerializeField] private float acceleration = 6;  // Speed increase rate
    [SerializeField] private float maxSpeed = 3;     // Maximum speed
    [SerializeField] private float initJumpForce = 5;     // Upward force applied when jumping
    [SerializeField] private float gravity = -9.81f;   // Gravity applied to the camera
    [SerializeField] private float maxGravity = -3;   // Max gravity applied to the camera
    [SerializeField] private float jumpTicks = 20;   // Max gravity applied to the camera
    [SerializeField] private float fogStart = 15; // Distance from player fog starts
    [SerializeField] private float fogEnd = 20; // Distance it turns fully opague
    private float jumpCount = 0; // Checker for grounded, debugging
    private bool grounded = true; // Checker for grounded, debugging
    [SerializeField] private Vector3 velocity = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        RenderSettings.fog = true; // Set up fog presets
        RenderSettings.fogColor = Color.black;
        RenderSettings.fogMode = FogMode.Linear;
    }

    // From https://discussions.unity.com/t/how-can-i-check-if-my-rigidbody-player-is-grounded/256346
    void isJumping(bool jumping)
    {
        grounded = controller.isGrounded;
        if (grounded && jumping)
        {
            jumpCount = jumpTicks;
        }
    }

    void Update()
    {
        // Get input from WASD keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Determine the direction relative to the camera's orientation
        Vector3 moveDirection = playerCamera.right * horizontal + playerCamera.forward * vertical;
        moveDirection.y = 0f; // Ensure movement is only on the horizontal plane

        // Calculate horizontal velocity
        if (moveDirection.magnitude > 0 && grounded)
        {
            // Accelerate with movement while on the ground
            velocity += moveDirection.normalized * acceleration * Time.deltaTime;
            Vector2 horMovement = new Vector2(velocity.x, velocity.z);
            horMovement = Vector2.ClampMagnitude(horMovement, maxSpeed);
            velocity.x = horMovement.x;
            velocity.z = horMovement.y;
        }
        else if (moveDirection.magnitude == 0)// && grounded)
        {
            // Decelerate when no input is given
            velocity.x *= 0.8f;
            velocity.z *= 0.8f;
            if (Mathf.Abs(velocity.x + velocity.z) < 0.01f)
            {
                velocity.x = 0.0f;
                velocity.z = 0.0f;
            }
        }
        else
        {
            // Accelerate slower when in the air
            velocity += moveDirection.normalized * (acceleration / 2) * Time.deltaTime;
            Vector2 horMovement = new Vector2(velocity.x, velocity.z);
            horMovement = Vector2.ClampMagnitude(horMovement, maxSpeed);
            velocity.x = horMovement.x;
            velocity.z = horMovement.y;
        }

        // Jump Input Handling
        isJumping(Input.GetKeyDown(KeyCode.Space));

        // Apply gravity and jump mechanics
        if (jumpCount > 0)
        {
            if (jumpCount == jumpTicks)
            {
                velocity.y = initJumpForce;
            }
            velocity.y += (1.0f - jumpCount / (jumpTicks)) * Time.deltaTime;
            jumpCount -= 1;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        velocity.y = Mathf.Clamp(velocity.y, maxGravity, 15f);

        // Move the camera according to the calculated velocity
        controller.Move(velocity * Time.deltaTime);

        // Add the fog, researched fog using ChatGPT
        RenderSettings.fogStartDistance = fogStart;
        RenderSettings.fogEndDistance = fogEnd;
    }
}
