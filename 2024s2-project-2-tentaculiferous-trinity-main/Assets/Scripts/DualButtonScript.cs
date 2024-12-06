using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualButtonPressurePlate : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public GameObject objectToMove;    // Object to move
        public Vector3 moveOffset;         // How much the object should move relative to its original position
        [HideInInspector] public Vector3 targetPosition;
        [HideInInspector] public Vector3 antiTargetPosition;
        [HideInInspector] public Vector3 position1;  // Store the original position of the object
        [HideInInspector] public Vector3 position2;
    }

    public MovableObject[] movableObjects;  // Object we want to move
    public float timeToMove = 5.0f;
    public int buttonID;                    // Unique ID for each button (e.g., 1 for button1, 2 for button2)

    // Static variables to track if each button is pressed
    private static int button1Pressed = 0;
    private static int button2Pressed = 0;

    void Start()
    {
        // Store the original position of each object and calculate the target position
        foreach (MovableObject obj in movableObjects)
        {
            obj.position1 = obj.objectToMove.transform.position;
            obj.position2 = obj.position1 + obj.moveOffset;
            obj.targetPosition = obj.position1;
            obj.antiTargetPosition = obj.position2;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object pressing the button is the player or a sliding block
        Debug.Log(other.name);
        if (other.CompareTag("Player") || other.CompareTag("SlidingBlock"))
        {
            UpdateButtonState(buttonID, 1);  // Mark the button as pressed
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("SlidingBlock"))
        {
            UpdateButtonState(buttonID, 1);  // Mark the button as pressed
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the object leaving the button is the player or a sliding block
        if (other.CompareTag("Player") || other.CompareTag("SlidingBlock"))
        {
            UpdateButtonState(buttonID, 0);  // Mark the button as released
        }
    }

    void UpdateButtonState(int buttonID, int state)
    {
        // Update the state of the correct button (1 or 2)
        if (buttonID == 1)
        {
            button1Pressed = state;
        }
        else if (buttonID == 2)
        {
            button2Pressed = state;
        }

        if (button1Pressed == 1 && button2Pressed == 1)
        {
            foreach (MovableObject obj in movableObjects)
            {
                obj.targetPosition = obj.position2;
                obj.antiTargetPosition = obj.position1;
            }
        }
        else
        {
            foreach (MovableObject obj in movableObjects)
            {
                obj.targetPosition = obj.position1;
                obj.antiTargetPosition = obj.position2;
            }
        }
    }


    void Update()
    {
        if (buttonID == 1)
        {
            foreach (MovableObject obj in movableObjects)
            {
                Vector3 newPosition = obj.objectToMove.transform.position + (obj.targetPosition - obj.antiTargetPosition) * (Time.deltaTime / timeToMove);
                if (Vector3.Distance(obj.antiTargetPosition, obj.targetPosition) < Vector3.Distance(obj.objectToMove.transform.position, obj.antiTargetPosition))
                {
                    newPosition = obj.targetPosition;
                }
                obj.objectToMove.transform.position = newPosition;
            }
        }
    }
}
