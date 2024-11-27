using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro;

public class AppealSpawnBehavior : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Two obstacle prefabs
    public string[][] obstacleTexts; // Text pools for each prefab
    public Transform spawnPoint; // Where to spawn obstacles
    public TextMeshProUGUI displayText; // TextMeshPro element for displaying messages
    public float spawnTime; // Time between spawns
    public float spawnRangeX = 0.5f; // Range for random X positions

    private float timer;

    void Start()
    {
        // Initialize text pools
        obstacleTexts = new string[][]
        {
            new string[] { "Appeal Denied 1", "Appeal Denied 2", "Appeal Denied 3", "Appeal Denied 4", "Appeal Denied 5" }, // Text for prefab 1
            new string[] { "Appeal Granted 1", "Appeal Granted 2", "Appeal Granted 3", "Appeal Granted 4", "Appeal Granted 5" } // Text for prefab 2
        };
    }

    void Update()
    {
        timer -= Time.deltaTime;

              if (GameManager.Score == 0){
            spawnTime = 15f;
        }
        else if (GameManager.Score == 1){
            spawnTime = 13f;
        }
        else if (GameManager.Score == 2){
            spawnTime = 11f;
        }
        else if (GameManager.Score == 3){
            spawnTime = 10f;
        }
        else if (GameManager.Score == 4){
            spawnTime = 7f;
        }
        else if (GameManager.Score == 5){
            spawnTime = 6f;
        }
        else if (GameManager.Score == 6){
            spawnTime = 5f;
        }
        else if (GameManager.Score == 7){
            spawnTime = 4f;
        }
        else if (GameManager.Score == 8){
            spawnTime = 3f;
        }
        else if (GameManager.Score == 9){
            spawnTime = 2f;
        }

        if (timer <= 0f)
        {
            SpawnObstacleWithText();
            timer = spawnTime;
        }
    }

    void SpawnObstacleWithText()
    {
        // Randomize X position for spawning
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Select a random prefab and corresponding text pool
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[prefabIndex];

        // Randomly pick a text from the selected prefab's text pool
        string[] textPool = obstacleTexts[prefabIndex];
        string selectedText = textPool[Random.Range(0, textPool.Length)];

        // Spawn the prefab and display the text
        Instantiate(selectedPrefab, position, spawnPoint.rotation);
        displayText.text = selectedText;
    }
}





