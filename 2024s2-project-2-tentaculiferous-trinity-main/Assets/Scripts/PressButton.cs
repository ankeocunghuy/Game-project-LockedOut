using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public GameObject objectToMove;
        public Vector3 moveOffset;       // How much the object should move relative to its original position
        [HideInInspector] public Vector3 targetPosition;
        [HideInInspector] public Vector3 antiTargetPosition;
        [HideInInspector] public Vector3 position1;  // Store the original position of the object
        [HideInInspector] public Vector3 position2;
    }

    public MovableObject[] movableObjects;  // Array to hold multiple objects and their movement offsets
    public float timeToMove = 5.0f;          // Time in seconds to travel from one position to the next
    [HideInInspector] private int player_detected = 0;
    void Start()
    {
        // Store the original position of each object
        foreach (MovableObject obj in movableObjects)
        {
            obj.position1 = obj.objectToMove.transform.position;
            obj.position2 = obj.position1 + obj.moveOffset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (MovableObject obj in movableObjects)
            {
                obj.targetPosition = obj.position2;
                obj.antiTargetPosition = obj.position1;
                player_detected = 1;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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

        foreach (MovableObject obj in movableObjects)
        {
            if (player_detected == 1)
            {
                Vector3 newPosition = obj.objectToMove.transform.position + (obj.targetPosition - obj.antiTargetPosition) * (Time.deltaTime / timeToMove);
                if (Vector3.Distance(obj.antiTargetPosition, obj.targetPosition) < Vector3.Distance(obj.objectToMove.transform.position, obj.antiTargetPosition))
                {
                    newPosition = obj.targetPosition;
                }
                obj.objectToMove.transform.position = newPosition;
                if (obj.objectToMove.transform.position == obj.position1)
                {
                    player_detected = 0;
                }
            }
        }
    }
}