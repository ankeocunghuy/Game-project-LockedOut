using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    
    public string sceneToLoad = "Server1";

    // Optional: Specify the tag required for collision
    public string playerTag = "Player";

    private void OnCollision(Collider other)
    {
        // Check if the colliding object has the required tag
        if (other.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Door Collision Detected: " + other.gameObject.name);
            LoadScene();
        }
    }

    void LoadScene()
    {
        Debug.Log("Level load trigger activated: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad); // Load the specified scene
    }
}