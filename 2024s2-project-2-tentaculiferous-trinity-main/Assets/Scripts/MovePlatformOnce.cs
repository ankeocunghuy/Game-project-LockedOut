using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnce : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public GameObject objectToMove;
        public Vector3 moveOffset;       // How much the object should move relative to its original position
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
            player_detected = 1;
        }
    }

    void Update()
    {
        if (player_detected == 1)
        {
            foreach (MovableObject obj in movableObjects)
            {
                Vector3 newPosition = obj.objectToMove.transform.position + (obj.position2 - obj.position1) * (Time.deltaTime / timeToMove);
                if (Vector3.Distance(obj.position1, obj.position2) < Vector3.Distance(obj.objectToMove.transform.position, obj.position1))
                {
                    newPosition = obj.position2;
                    player_detected = 2;
                }
                obj.objectToMove.transform.position = newPosition;
            }
        }
    }
}