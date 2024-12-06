using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform targetObject;  // The object whose proximity triggers rotation
    [SerializeField] private Transform[] rotatingObjects;  // The objects that rotate
    [SerializeField] private float triggerDistance = 2.0f;  // Distance to trigger the rotation
    [SerializeField] private float timeToTurn = 3.0f;  // Time to rotate by 90 degrees
    [SerializeField] private float rotation = -90; 

    private bool[] isRotating;
    private bool[] hasRotated;  // New flag to prevent multiple activations

    void Start()
    {
        isRotating = new bool[rotatingObjects.Length];
        hasRotated = new bool[rotatingObjects.Length];  // Initialize the rotation status
    }

    void Update()
    {
        for (int i = 0; i < rotatingObjects.Length; i++)
        {
            if (!isRotating[i] && !hasRotated[i])
            {
                // Check the distance between the targetObject and each rotating object
                if (Vector3.Distance(targetObject.position, rotatingObjects[i].position) <= triggerDistance)
                {
                    StartCoroutine(RotateObject(rotatingObjects[i], i));
                }
            }
        }
    }

    IEnumerator RotateObject(Transform obj, int index)
    {
        isRotating[index] = true;

        Quaternion startRotation = obj.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotation, 0);  // Rotate by 90 degrees on the Y axis

        float elapsedTime = 0;

        while (elapsedTime < timeToTurn)
        {
            obj.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / timeToTurn);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.rotation = endRotation;
        isRotating[index] = false;  // Reset the rotation flag after completing
        hasRotated[index] = true;   // Mark as already rotated to prevent further activations
    }
}
