using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour
{
    public float rotationAngle = 90f;        // The angle to rotate (90 degrees)
    public float rotationSpeed = 2f;         // Speed of rotation
    public float delayTime = 2f;             // Time between rotations
    public Vector3 rotationAxis = Vector3.up; // Rotation axis (X, Y, or Z)

    private bool isRotating = false;         // Track whether it's rotating
    private Quaternion targetRotation;       // The target rotation (90 degrees from current)
    private Quaternion originalRotation;     // The original rotation of the block

    void Start()
    {
        // Store the initial rotation
        originalRotation = transform.rotation;

        // Call the "ToggleRotation" method every `delayTime` seconds
        InvokeRepeating("ToggleRotation", 0f, delayTime);
    }

    void ToggleRotation()
    {
        // If the block is at the original rotation, set the target to rotate by 90 degrees around the chosen axis
        if (!isRotating)
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles + (rotationAxis * rotationAngle));
            isRotating = true;
        }
        // If it's already rotated, set the target to rotate back to the original
        else
        {
            targetRotation = originalRotation;
            isRotating = false;
        }
    }

    void Update()
    {
        // Smoothly rotate the block towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
