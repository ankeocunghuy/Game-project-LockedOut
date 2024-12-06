using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLava : MonoBehaviour
{
    [SerializeField] float yThreshold = -5f; // Threshold for Y position
    [SerializeField] Vector3 targetPosition; // Target position to teleport the player

    private void Update()
    {
        // Check if the player's Y position is below the specified threshold
        if (transform.position.y < yThreshold)
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        // Move the player to the specified target position
        transform.position = targetPosition;
    }
}
