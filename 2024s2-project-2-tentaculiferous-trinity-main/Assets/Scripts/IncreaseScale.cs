using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasaeScale : MonoBehaviour
{
    public float moveSpeed = 1.0f;         // Speed of upward movement
    public float targetHeight = 5.0f;      // Y position to stop moving at

    void Update()
    {
        // Check if the object has reached the target height
        if (transform.position.y < targetHeight)
        {
            // Create a vector to move the object upward by moveSpeed per second
            Vector3 positionChange = new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f);

            // Apply the movement
            transform.position += positionChange;
        }
        else
        {
            // Optional: Stop movement when the target height is reached
            transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
        }
    }
}
