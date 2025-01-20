using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public Transform spawnPoint; 
    public float spawnRangeX = 3f; // How far left/right to spawn
    private float _spawnTime; // Time between spawns calculated in Update
    private float _timerFinish = 0f; // Time to spawn again

    private float _timer; 
    private float [] _obstacleSpawnTimes = {10f, 9f, 8f, 7f, 6f, 5f, 4f, 3f, 2f, 1f};

    private void Update()
    {
        _timer -= Time.deltaTime; // - time elapsed since last, therefore decreases with hightened score

        if (GameManager.Score >= 0 && GameManager.Score < _obstacleSpawnTimes.Length)
        {
            _spawnTime = _obstacleSpawnTimes[GameManager.Score];
        }
        else
        {
            _spawnTime = _obstacleSpawnTimes[_obstacleSpawnTimes.Length - 1]; 
        }

        if(_timer <= _timerFinish) // if timer is less than or equal to 0 (important to have less than as well)
        {
            SpawnObstacle(); // calling method to spawn obstacle randomly 
            _timer = _spawnTime;
        }
    }

    private void SpawnObstacle()
    {
        // Random X position near spawn point
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Pick a random obstacle and spawn it
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], position, spawnPoint.rotation);
    }

    /*private void Update()
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
    }*/

    
}
