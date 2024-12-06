using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomRandomAudioPlayer : MonoBehaviour
{
    // Audio clip to play
    public AudioClip audioClip;       // Choose the audio to play

    // AudioSource component to play the sound
    private AudioSource audioSource;

    // Reference to the player (assign in the inspector)
    public Transform player;

    // Distance behind the player where the audio will play
    public float distanceBehindPlayer = 2f;

    // Minimum and maximum random delay in seconds
    public float minDelay = 8f;
    public float maxDelay = 12f;

    // Scene name to check
    public string targetSceneName;    // Choose the target scene

    // Tag of the object that will trigger sound change
    public string targetObjectTag;    // Choose the tag of the target object to trigger the sound

    // Audio clip to play when object is contacted
    public AudioClip contactAudioClip; // Choose the audio to play on object contact

    // Internal flag to ensure object audio plays only once
    private bool hasPlayedContactAudio = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure that the AudioSource is set to 3D sound
        audioSource.spatialBlend = 1.0f; // 1 = fully 3D, 0 = fully 2D

        // Start the coroutine to play the sound at random intervals
        StartCoroutine(PlayAudioRandomly());
    }

    // Coroutine to play audio at random intervals
    IEnumerator PlayAudioRandomly()
    {
        while (true)
        {
            // Check if the current active scene matches the specified scene name
            if (SceneManager.GetActiveScene().name == targetSceneName)
            {
                // Place the audio source behind the player
                Vector3 behindPlayerPosition = player.position - player.forward * distanceBehindPlayer;
                transform.position = behindPlayerPosition;

                // Play the audio clip
                audioSource.PlayOneShot(audioClip);
            }

            // Wait for a random time between minDelay and maxDelay before playing the next sound
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Detect collision with the specified object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the object that has the specified tag
        if (other.CompareTag(targetObjectTag) && !hasPlayedContactAudio)
        {
            // Stop the current audio
            audioSource.Stop();

            // Play the new contact audio clip
            audioSource.clip = contactAudioClip;
            audioSource.loop = false;  // Play it once
            audioSource.Play();

            hasPlayedContactAudio = true;  // Ensure the contact audio plays only once
        }
    }
}
