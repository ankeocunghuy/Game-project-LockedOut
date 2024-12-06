 using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    // Scene names for different tags
    public string sceneForTag1;
    public string sceneForTag2;
    public string sceneForTag3;

    // Time to wait before changing to the final scene
    public float delayTime = 1f; 

    // Tags for the objects that trigger the scene change
    public string triggeringTag1;
    public string triggeringTag2;
    public string triggeringTag3; 

    // This method is called when the trigger collider attached to the GameObject this script is attached to enters another trigger collider
    private void OnTriggerEnter(Collider other)
    {
        HandleCollisionOrTrigger(other.gameObject.tag);
    }

    // Method to handle trigger events based on the tag
    private void HandleCollisionOrTrigger(string tag)
    {
        if (tag == triggeringTag1)
        {
            DoorManager.doorID = 1;
            StartCoroutine(TransitionToScene(sceneForTag1));
        }
        else if (tag == triggeringTag2)
        {
            DoorManager.doorID = 2;
            StartCoroutine(TransitionToScene(sceneForTag2));
        } else if (tag == triggeringTag3)
        {
            DoorManager.doorID = 3;
            StartCoroutine(TransitionToScene(sceneForTag2));
        }
    }

    // Coroutine to handle the transition with a delay
    IEnumerator TransitionToScene(string targetScene)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Load the final scene after the delay
        SceneManager.LoadScene(targetScene);
    }
}
