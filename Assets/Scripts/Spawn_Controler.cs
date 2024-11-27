
using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objectToSpawn; // Objekter der skal spawnes
    public GameObject objectToSpawn2; // Objekter der skal spawnes
    public BoxCollider spawnArea; // Området hvor objekterne skal spawnes
    public float initialSpawnInterval = 10f; // Start spawn-interval
    public float minSpawnInterval = 2f; // Minimum spawn-interval
    public float intervalReductionRate = 0.1f; // Hvor meget intervallet reduceres over tid
    public int initialMaxObjects = 4; // Start grænse for antal objekter
    public int maxObjectsIncrementRate = 1; // Hvor meget max objekter øges over tid
    public float maxObjectsIncreaseInterval = 60f; // Tid før max-objekter øges

    private float currentSpawnInterval; // Aktuelt spawn-interval
    private int currentMaxObjects; // Aktuel grænse for antal objekter
    private int currentObjectCount; // Aktuelt antal spawnede objekter

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        currentMaxObjects = initialMaxObjects;
        currentObjectCount = 0;

        // Start coroutines
        StartCoroutine(SpawnObjectRoutine());
        StartCoroutine(IncreaseMaxObjectsOverTime());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Vent på det nuværende spawn-interval
            yield return new WaitForSeconds(currentSpawnInterval);

            // Reducer spawn-intervallet over tid (med en nedre grænse)
            if (currentSpawnInterval > minSpawnInterval)
            {
                currentSpawnInterval -= intervalReductionRate;
            }

            // Tjek om vi kan spawne flere objekter
            if (currentObjectCount < currentMaxObjects)
            {
                SpawnObject(objectToSpawn);
                SpawnObject(objectToSpawn2);
            }
        }
    }

    void SpawnObject(GameObject objectToSpawn)
    {
        // Generer en tilfældig position inden for spawn-området
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        );

        // Spawn objektet
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        currentObjectCount++;
    }

    IEnumerator IncreaseMaxObjectsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(maxObjectsIncreaseInterval);
            currentMaxObjects += maxObjectsIncrementRate;
        }
    }

    Vector3 GetRandomPositionInBox(BoxCollider box)
    {
        // Generer en tilfældig position i box colliderens lokale koordinater
        Vector3 localPosition = new Vector3(
            Random.Range(-box.size.x / 2, box.size.x / 2),
            Random.Range(-box.size.y / 2, box.size.y / 2),
            Random.Range(-box.size.z / 2, box.size.z / 2)
        );

        // Konverter lokal position til verdenskoordinater
        return box.transform.TransformPoint(localPosition + box.center);
    }

    private void OnDrawGizmos()
    {
        // Tegn en visuel repræsentation af spawn-området i editoren
        if (spawnArea != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnArea.transform.TransformPoint(spawnArea.center), spawnArea.size);
        }
    }
}
