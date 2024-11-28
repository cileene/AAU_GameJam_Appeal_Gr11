using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public Transform spawnPoint; 
    public float spawnRangeX = 3f; // How far left/right to spawn
    private float _spawnTime; // Time between spawns

    private float _timer;

    void Update()
    {
        _timer -= Time.deltaTime; // Countdown the timer
        _spawnTime = GameManager.Score switch
        {
            0 => 10f,
            1 => 9f,
            2 => 8f,
            3 => 7f,
            4 => 6f,
            5 => 5f,
            6 => 4f,
            7 => 3f,
            8 => 2f,
            9 => 1f,
            _ => _spawnTime
        };

        if (_timer <= 0f)
        {
            SpawnObstacle(); // Spawn a new obstacle
            _timer = _spawnTime; // Reset the timer
        }
    }

    private void SpawnObstacle() //TODO: We need to understand this
    {
        // Random X position near spawn point
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Pick a random obstacle and spawn it
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], position, spawnPoint.rotation);
    }
}
