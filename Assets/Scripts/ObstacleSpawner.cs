using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Obstacles to spawn
    public Transform spawnPoint; // Where obstacles spawn
    public float spawnRangeX = 3f; // How far left/right to spawn
    private float spawnTime; // Time between spawns

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime; // Countdown the timer
        if (GameManager.Score == 0){
            spawnTime = 10f;
        }
        else if (GameManager.Score == 1){
            spawnTime = 9f;
        }
        else if (GameManager.Score == 2){
            spawnTime = 8f;
        }
        else if (GameManager.Score == 3){
            spawnTime = 7f;
        }
        else if (GameManager.Score == 4){
            spawnTime = 6f;
        }
        else if (GameManager.Score == 5){
            spawnTime = 5f;
        }
        else if (GameManager.Score == 6){
            spawnTime = 4f;
        }
        else if (GameManager.Score == 7){
            spawnTime = 3f;
        }
        else if (GameManager.Score == 8){
            spawnTime = 2f;
        }
        else if (GameManager.Score == 9){
            spawnTime = 1f;
        }

        if (timer <= 0f)
        {
            SpawnObstacle(); // Spawn a new obstacle
            timer = spawnTime; // Reset the timer
        }
    }

    void SpawnObstacle()
    {
        // Random X position near spawn point
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Pick a random obstacle and spawn it
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], position, spawnPoint.rotation);
    }
}
