using UnityEngine;

public class ChangeTagAndTrigger : MonoBehaviour
{
    public string newTag = "Correct"; // The new tag you want to assign
    public int interactionLimit = 3; // Number of interactions before changing the tag
    private int interactionCount = 0; // Tracks the number of interactions

    private BoxCollider boxCollider; // Specific reference to BoxCollider

    void Start()
    {
        // Get the BoxCollider component
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Increment the interaction count
        interactionCount++;

        // Check if the interaction count has reached the limit
        if (interactionCount >= interactionLimit)
        {
            // Change the tag
            gameObject.tag = newTag;

            // Set IsTrigger to true
            if (boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
        }
    }

    // Method to get the interaction count
    public int GetInteractionCount()
    {
        return interactionCount;
    }
}
