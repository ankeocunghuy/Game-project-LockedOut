using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    [SerializeField] float speed = 5f;          // Speed of the upward movement
    [SerializeField] float targetYPosition = 10f; // Y position where the object should reset
    [SerializeField] float startYPosition = 0f;   // Starting Y position to reset the object to

    private void Update()
    {
        // Move the object upward only on the Y axis
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Check if the object's Y position has reached or surpassed the target Y position
        if (transform.position.y >= targetYPosition)
        {
            // Reset only the Y position to the start Y position, keeping X and Z the same
            transform.position = new Vector3(transform.position.x, startYPosition, transform.position.z);
        }
    }
}
