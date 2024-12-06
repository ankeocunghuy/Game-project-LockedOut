using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Reset: MonoBehaviour
{
    void Update()
    {
        // Check if the 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
    }

    // Function to reset the level
    void ResetLevel()
    {
        // Get the current active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("Level Reset by pressing 'R'!");
    }
}
