using UnityEngine;

public class PushBackOnCollision : MonoBehaviour
{
    public Transform targetPosition; // The position the player will be pushed towards
    public float pushForce = 10f;    // The strength of the push

    private Rigidbody playerRb;

    void Start()
    {
        // Get the player's Rigidbody at the start of the game
        playerRb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with an object tagged as "Incorrect"
        if (collision.gameObject.CompareTag("Incorrect"))
        {
            // Calculate the direction vector from the player's current position to the target position
            Vector3 pushDirection = (targetPosition.position - transform.position).normalized;

            // Apply force to the player in the direction of the target position
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
