using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    // Code taken from ChatGPT and modified to fit purposes
    [SerializeField] private float mouseSensitivity = 200f;  // Sensitivity of the mouse movement
    [SerializeField] private Transform playerBody;           // Reference to the player's body (if camera is attached to the head)

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Determine the camera's yaw then pitch
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  // Clamp to prevent over-rotation
        yRotation += mouseX;

        // Adjust the camera's vertical rotation (pitch) only
        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the camera horizontally based on mouse input (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Keep the camera upright by resetting any tilt or roll
        Vector3 eulerAngles = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
