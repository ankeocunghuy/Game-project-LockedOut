using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFinalDoor : MonoBehaviour
{

    private bool doorOpen = false;
    public GameObject[] objectsToMove = new GameObject[3];
    public float moveDuration = 2.0f;
    [SerializeField] private Transform targetObject;
    [SerializeField] private float triggerDistance = 10.0f;
    [SerializeField] private float rotation = -90;
    private bool[] isRotating = new bool[3];
    private bool[] hasRotated = new bool[3];

    void Start()
    {
        
    }


    void Update()
    {
        if (ProgressTracker.Instance.AllLevelsCompleted() && !doorOpen)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!isRotating[i] && !hasRotated[i])
                {
                    if (Vector3.Distance(targetObject.position, objectsToMove[i].transform.position) <= triggerDistance)
                    {
                        StartCoroutine(RotateObject(objectsToMove[i], i));
                    }
                }
            }
        }
    }

    IEnumerator RotateObject(GameObject obj, int index)
    {
        isRotating[index] = true;

        Quaternion startRotation = obj.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotation, 0);

        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            obj.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = endRotation;
        isRotating[index] = false;
        hasRotated[index] = true;
        doorOpen = true;
    }
}
