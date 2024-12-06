using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // Reference to the Player object
    public GameObject playerObject;

    // Set the teleport location in the Inspector
    public Transform teleportLocation;

    // Reference to the player's Rigidbody (if applicable)
    private Rigidbody playerRigidbody;

    // Reference to the teleport audio clip
    public AudioClip teleportAudioClip;

    // Audio source component
    private AudioSource audioSource;

    private void Start()
    {
        // Get the player's Rigidbody component if they have one
        playerRigidbody = playerObject.GetComponent<Rigidbody>();

        // Initialize audio source if not present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject == playerObject)
        {
            // Teleport player
            Teleport(playerObject.transform);
        }
    }

    private void Teleport(Transform playerTransform)
    {
        // Play teleport audio clip
        audioSource.clip = teleportAudioClip;
        audioSource.Play();

        // Disable player movement temporarily
        playerTransform.GetComponent<PlayerMovement>().enabled = false;

        // Optionally disable physics if Rigidbody is present
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true; // Prevent physics issues during teleportation
        }

        // Store the current rotation of the player to preserve it
        Quaternion currentRotation = playerTransform.rotation;

        // Teleport player while keeping the rotation unchanged
        playerTransform.SetPositionAndRotation(teleportLocation.position, currentRotation);

        // Optionally re-enable physics if Rigidbody is present
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false; // Re-enable physics
        }

        // Re-enable player movement
        playerTransform.GetComponent<PlayerMovement>().enabled = true;
    }
}