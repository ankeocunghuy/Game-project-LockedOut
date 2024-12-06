using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        // Optional: Add a delay for a transition effect
        yield return new WaitForSeconds(3f); // Example 3 seconds delay

        // Load the correct scene based on the door ID
        switch (DoorManager.doorID)
        {
            case 1:
                SceneManager.LoadScene("Server1");
                break;
            case 2:
                SceneManager.LoadScene("Server2");
                break;
            case 3:
                SceneManager.LoadScene("Server3");
                break;
            default:
                Debug.LogError("Invalid door ID");
                break;
        }
    }
}
