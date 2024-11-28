
using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objectToSpawn; // Objekter der skal spawnes (yes fx)
    public GameObject objectToSpawn2; // Objekter der skal spawnes (No fx)
    public BoxCollider spawnArea; // Området hvor objekterne skal spawnes
    public float initialSpawnInterval = 10f; // Startintervallet (i sekunder) mellem hver gang et nyt objekt bliver spawnet.
    public float minSpawnInterval = 2f; // Den mindste tid (i sekunder), der kan gå mellem spawns.
    public float intervalReductionRate = 0.1f; // Hvor meget spawn-intervallet reduceres hver gang et nyt objekt bliver spawnet.
    public int initialMaxObjects = 4; // Det maksimale antal objekter, der kan eksistere i verdenen på én gang, når spillet starter.
    public int maxObjectsIncrementRate = 1; // Hvor mange ekstra objekter der kan være i verdenen, hver gang grænsen for maksimumsobjekter bliver øget.
    public float maxObjectsIncreaseInterval = 60f; // Hvor ofte (i sekunder) grænsen for maksimale objekter øges

    private float currentSpawnInterval; // Aktuelt spawn-interval (i sekunder)
    private int currentMaxObjects; // Aktuel grænse for antal objekter
    private int currentObjectCount; // Aktuelt antal spawnede objekter

    void Start() // Start-funktionen kaldes når objektet bliver oprettet
    {
        currentSpawnInterval = initialSpawnInterval; // Sæt startintervallet
        currentMaxObjects = initialMaxObjects; // Sæt startgrænsen for antal objekter
        currentObjectCount = 0; // Der er ingen objekter i verdenen endnu

        // Start rutiner
        StartCoroutine(SpawnObjectRoutine()); // Start rutine til at spawne objekter
        StartCoroutine(IncreaseMaxObjectsOverTime()); // Start rutine til at øge grænsen for maksimale objekter over tid
    }

    IEnumerator SpawnObjectRoutine() // Rutine til at spawne objekter
    {
        while (true)
        {
            // Vent på det nuværende spawn-interval
            yield return new WaitForSeconds(currentSpawnInterval);

            // Reducer spawn-intervallet over tid (med en nedre grænse)
            if (currentSpawnInterval > minSpawnInterval) // Hvis spawn-intervallet er større end den mindste værdi
            {
                currentSpawnInterval -= intervalReductionRate; // Reducer spawn-intervallet
            }

            // Tjek om vi kan spawne flere objekter
            if (currentObjectCount < currentMaxObjects) // Hvis der er plads til flere objekter
            {
                SpawnObject(objectToSpawn); 
                SpawnObject(objectToSpawn2); 
            }
        }
    }

    void SpawnObject(GameObject objectToSpawn) // Funktion til at spawne objekter
    {
        // Generer en tilfældig position inden for spawn-området
        Vector3 spawnPosition = new Vector3( 
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        );

        // Spawn objektet
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); 
        currentObjectCount++; // Tæl objektet med i antallet af spawnede objekter
    }

    IEnumerator IncreaseMaxObjectsOverTime() // Rutine til at øge grænsen for maksimale objekter over tid
    {
        while (true) // Kør for evigt
        {
            yield return new WaitForSeconds(maxObjectsIncreaseInterval); // Vent på intervallet
            currentMaxObjects += maxObjectsIncrementRate; // Øg grænsen for maksimale objekter
        }
    }

    private void OnDrawGizmos() // Funktion til at tegne i editoren Den skal ikke bruges til andet end at tegne i editoren og vise hvor tingene spawner
    {
        // Tegn en visuel repræsentation af spawn-området i editoren
        if (spawnArea != null) // Hvis spawn-området er sat
        {
            Gizmos.color = Color.green; // Sæt farven til grøn
            Gizmos.DrawWireCube(spawnArea.transform.TransformPoint(spawnArea.center), spawnArea.size); // Tegn en wireframe kube
        }
    }
}
