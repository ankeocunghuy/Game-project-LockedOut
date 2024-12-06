using System.Collections;
using UnityEngine;

public class Server2ExitDoor : MonoBehaviour
{
    [SerializeField] private Transform targetObject1;  // First object whose proximity triggers rotation
    [SerializeField] private Transform targetObject2;  // Second object whose proximity triggers rotation
    [SerializeField] private Transform[] rotatingObjects;  // The objects that rotate
    [SerializeField] private float triggerDistance = 5.0f;  // Distance to trigger the rotation
    [SerializeField] private float timeToTurn = 3.0f;  // Time to rotate by 90 degrees
    [SerializeField] private float rotation = 110;
    [SerializeField] private int levelIndex;  // Level index to mark as completed in ProgressTracker

    private bool[] isRotating;
    private bool[] hasRotated;

    void Start()
    {
        isRotating = new bool[rotatingObjects.Length];
        hasRotated = new bool[rotatingObjects.Length];
    }

    void Update()
    {
        for (int i = 0; i < rotatingObjects.Length; i++)
        {
            if (!isRotating[i] && !hasRotated[i])
            {
                if (IsWithinRange(targetObject1, rotatingObjects[i]) || IsWithinRange(targetObject2, rotatingObjects[i]))
                {
                    StartCoroutine(RotateObject(rotatingObjects[i], i));
                }
            }
        }
    }

    bool IsWithinRange(Transform target, Transform rotatingObject)
    {
        return Vector3.Distance(target.position, rotatingObject.position) <= triggerDistance;
    }

    IEnumerator RotateObject(Transform obj, int index)
    {
        isRotating[index] = true;

        Quaternion startRotation = obj.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotation, 0);

        float elapsedTime = 0;

        while (elapsedTime < timeToTurn)
        {
            obj.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / timeToTurn);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.rotation = endRotation;
        isRotating[index] = false;
        hasRotated[index] = true;

        // Mark the level as completed in ProgressTracker
        if (ProgressTracker.Instance != null)
        {
            ProgressTracker.Instance.MarkLevelCompleted(levelIndex);
        }
        else
        {
            Debug.LogError("ProgressTracker instance not found!");
        }
    }
}
