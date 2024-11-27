using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to be spawned
    public float spawnInterval = 10f; // Time interval between spawns
    public BoxCollider spawnArea; // The area within which objects will be spawned
    private GameObject currentSpawnedObject; // Reference to the currently spawned object

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Check if an object already exists
            if (currentSpawnedObject == null)
            {
                // Get a random position within the spawn area
                Vector3 spawnPosition = GetRandomPositionInBox(spawnArea);

                // Instantiate the object and store a reference to it
                currentSpawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPositionInBox(BoxCollider box)
    {
        // Calculate the center and size of the box collider
        Vector3 center = box.center + box.transform.position;
        Vector3 size = box.size;

        // Return a random position within the box collider
        return new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            Random.Range(center.y - size.y / 2, center.y + size.y / 2),
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );
    }
}
