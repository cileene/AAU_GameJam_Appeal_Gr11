using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public Transform spawnPoint; 
    public float spawnRangeX = 3f; // How far left/right to spawn
    private float _spawnTime; // Time between spawns

    private float _timer;

    private void Update()
    {
        _timer -= Time.deltaTime; // Countdown the timer
        if (GameManager.Score == 0)
            _spawnTime = 10f;
        else if (GameManager.Score == 1)
            _spawnTime = 9f;
        else if (GameManager.Score == 2)
            _spawnTime = 8f;
        else if (GameManager.Score == 3)
            _spawnTime = 7f;
        else if (GameManager.Score == 4)
            _spawnTime = 6f;
        else if (GameManager.Score == 5)
            _spawnTime = 5f;
        else if (GameManager.Score == 6)
            _spawnTime = 4f;
        else if (GameManager.Score == 7)
            _spawnTime = 3f;
        else if (GameManager.Score == 8)
            _spawnTime = 2f;
        else if (GameManager.Score == 9)
            _spawnTime = 1f;
        else
            _spawnTime = _spawnTime;

        if (_timer <= 0f)
        {
            SpawnObstacle(); // Spawn a new obstacle
            _timer = _spawnTime; // Reset the timer
        }
    }

    private void SpawnObstacle() //TODO: Focus here
    {
        // Random X position near spawn point
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Pick a random obstacle and spawn it
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], position, spawnPoint.rotation);
    }
}
