using System.Collections;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    // Singleton instance
    public static ProgressTracker Instance { get; private set; }

    public bool[] levelsCompleted;
    

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        levelsCompleted = new bool[3];
    }

    public void MarkLevelCompleted(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelsCompleted.Length)
        {
            levelsCompleted[levelIndex] = true;
            Debug.Log("Level " + levelIndex + " completed!");

            if (AllLevelsCompleted())
            {
                Debug.Log("All levels completed!");
            }
        }
    }

    public bool AllLevelsCompleted()
    {
        foreach (bool completed in levelsCompleted)
        {
            if (!completed) return false;
        }
        return true;
    }

    void Update()
    {
    }
}
