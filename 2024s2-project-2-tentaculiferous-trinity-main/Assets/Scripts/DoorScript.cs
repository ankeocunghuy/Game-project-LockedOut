using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int doorID; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorManager.doorID = doorID; // Store door ID in static variable
            SceneManager.LoadScene("TransitionScene"); // Load the transition scene
        }
    }
}
