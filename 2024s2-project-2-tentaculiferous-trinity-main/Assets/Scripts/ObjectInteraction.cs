using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private Transform topRightPosition; // Reference to where the object should move (top right)
    [SerializeField] private TextMeshProUGUI scoreText; // UI Text for displaying the score
    [SerializeField] private float moveSpeed = 5f; // Speed at which the object moves
    private int score = 0; // Score counter

    private bool isMovingToTopRight = false;
    private Transform objectToMove; // The object currently being interacted with

    // On trigger interaction with an object
    private void OnTriggerEnter(Collider other)
    {
        // Assuming the object has a tag "Test"
        if (other.gameObject.CompareTag("Test"))
        {
            objectToMove = other.transform;
            isMovingToTopRight = true; // Start moving the object to the top right
            score++; // Increment the score
            UpdateScore(); // Update the score UI
        }
    }

    // Update the score text on the UI
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        // If an object is set to move to the top right, move it
        if (isMovingToTopRight && objectToMove != null)
        {
            // Move the object to the top-right position smoothly
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, topRightPosition.position, moveSpeed * Time.deltaTime);

            // Check if the object has reached the target position
            if (Vector3.Distance(objectToMove.position, topRightPosition.position) < 0.1f)
            {
                isMovingToTopRight = false; // Stop moving
            }
        }
    }
}
