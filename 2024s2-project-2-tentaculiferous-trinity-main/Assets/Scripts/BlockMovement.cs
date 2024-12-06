using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Variables to control movement range, speed, and direction
    public float moveRange = 5f;     // The distance the block moves in any direction
    public float moveSpeed = 2f;     // The speed of the block's movement
    public Vector3 moveDirection = Vector3.right;  // Movement direction (X, Y, Z)
    public float delayTime = 1f;     // Delay time before changing direction

    private Vector3 startPosition;   // Starting position of the block
    private bool movingForward = true;
    private bool isWaiting = false;  // To track if the block is waiting

    void Start()
    {
        // Store the initial position of the block
        startPosition = transform.position;
    }

    void Update()
    {
        // Only move the block if it's not waiting (during the delay)
        if (!isWaiting)
        {
            // Calculate how far the block has moved from the starting point
            float distance = Vector3.Distance(startPosition, transform.position);

            // If the block exceeds the move range, trigger the change of direction with a delay
            if (distance >= moveRange)
            {
                StartCoroutine(ChangeDirectionAfterDelay());
            }

            // Move the block in the specified direction and reverse if necessary
            if (movingForward)
            {
                transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-moveDirection.normalized * moveSpeed * Time.deltaTime);
            }
        }
    }

    // Coroutine to handle delay before changing direction
    IEnumerator ChangeDirectionAfterDelay()
    {
        isWaiting = true; // Set the waiting flag to true
        yield return new WaitForSeconds(delayTime); // Wait for the specified delay time
        movingForward = !movingForward; // Change the direction
        startPosition = transform.position; // Update the starting position
        isWaiting = false; // Set the waiting flag back to false to allow movement
    }
}
