using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from ChatGPT with modifications

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject grassPrefab; // Prefab for Grass
    [SerializeField] private GameObject grassWithChairPrefab; // Prefab for GrassWithChair
    [SerializeField] private GameObject stagePodiumPrefab; // Prefab for Stage
    [SerializeField] private GameObject playerInstance; // Prefab for player
    [SerializeField] private float viewDistance = 50f; // Distance within which assets are loaded
    // private Transform cameraTransform; // Camera position
    private Dictionary<Vector2, GameObject> spawnedObjects = new Dictionary<Vector2, GameObject>();
    private GameObject stageInstance;

    void Start()
    {
        // Instantiate the stage and podium at the start and keep them in the scene
        stageInstance = Instantiate(stagePodiumPrefab, new Vector3(-5f, -0.26f, 0.8f), Quaternion.Euler(0, 90, 0));
        playerInstance.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        // Get the camera position
        Vector3 cameraPos = playerInstance.transform.position;

        // Calculate the boundaries within which objects should be spawned
        int minX = Mathf.FloorToInt((cameraPos.x - viewDistance) / 1);
        int maxX = Mathf.FloorToInt((cameraPos.x + viewDistance) / 1);
        int minY = Mathf.FloorToInt((cameraPos.z - viewDistance) / 1);
        int maxY = Mathf.FloorToInt((cameraPos.z + viewDistance) / 1);

        // Spawn objects within view distance
        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                Vector2 gridPosition = new Vector2(x, y);

                if (!spawnedObjects.ContainsKey(gridPosition))
                {
                    // Determine which prefab to spawn
                    GameObject prefabToSpawn = (x < 0 || (y < 2 && y > -2)) ? grassPrefab : grassWithChairPrefab;

                    // Instantiate the prefab at the calculated position
                    Vector3 spawnPosition = new Vector3(x * 1, 0, y * 1);
                    GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.Euler(0f, -90f, 0f));

                    // Add the spawned object to the dictionary
                    spawnedObjects[gridPosition] = spawnedObject;
                }
            }
        }

        // Despawn objects outside of view distance
        List<Vector2> keysToRemove = new List<Vector2>();

        foreach (var kvp in spawnedObjects)
        {
            Vector3 objPosition = kvp.Value.transform.position;
            float distanceToCamera = Vector3.Distance(cameraPos, objPosition);

            if (distanceToCamera > viewDistance)
            {
                Destroy(kvp.Value);
                keysToRemove.Add(kvp.Key);
            }
        }

        // Remove despawned objects from the dictionary
        foreach (Vector2 key in keysToRemove)
        {
            spawnedObjects.Remove(key);
        }
    }
}
