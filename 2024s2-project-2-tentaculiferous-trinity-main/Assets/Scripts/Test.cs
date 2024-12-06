using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnInteraction : MonoBehaviour
{
    public string intermediateScene; // The scene to load initially
    public string targetScene; // The scene to load after the wait
    public string playerTag = "Player"; 
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the player tag
        if (other.CompareTag(playerTag))
        {
            StartCoroutine(TransitionScenes());
        }
    }

    private IEnumerator TransitionScenes()
    {
        // Load the intermediate scene
        SceneManager.LoadScene(intermediateScene);

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Load the target scene
        SceneManager.LoadScene(targetScene);
    }
}
