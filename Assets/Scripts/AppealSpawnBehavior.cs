using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro;
using UnityEngine.Serialization;

public class AppealSpawnBehavior : MonoBehaviour
{
    public GameObject[] appealPrefabs; // Two obstacle prefabs
    private string[][] _appealTexts; 
    public Transform spawnPoint; 
    public TextMeshProUGUI displayText; // TextMeshPro element for displaying messages
    public float spawnTime; // Time between spawns
    public float spawnRangeX = 0.5f; // Range for random X positions

    private float _timer;

    void Start()
    {
        // Initialize text pools
        _appealTexts = new string[][]
        {
            new string[]
            {
                "Appeal Denied 1", 
                "Appeal Denied 2", 
                "Appeal Denied 3", 
                "Appeal Denied 4", 
                "Appeal Denied 5"
            }, // Text for prefab 1
            new string[]
            {
                "Appeal Granted 1", 
                "Appeal Granted 2", 
                "Appeal Granted 3", 
                "Appeal Granted 4", 
                "Appeal Granted 5"
            } // Text for prefab 2
        };
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        spawnTime = GameManager.Score switch
        {
            0 => 15f,
            1 => 13f,
            2 => 11f,
            3 => 10f,
            4 => 7f,
            5 => 6f,
            6 => 5f,
            7 => 4f,
            8 => 3f,
            9 => 2f,
            _ => spawnTime
        };

        if (_timer <= 0f)
        {
            SpawnPrefabWithText();
            _timer = spawnTime;
        }
    }

    private void SpawnPrefabWithText() //TODO: We need to understand this
    {
        // Randomize X position for spawning
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 position = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        // Select a random prefab and corresponding text pool
        int prefabIndex = Random.Range(0, appealPrefabs.Length);
        GameObject selectedPrefab = appealPrefabs[prefabIndex];

        // Randomly pick a text from the selected prefab's text pool
        string[] textPool = _appealTexts[prefabIndex];
        string selectedText = textPool[Random.Range(0, textPool.Length)];

        // Spawn the prefab and display the text
        Instantiate(selectedPrefab, position, spawnPoint.rotation);
        displayText.text = selectedText;
    }
}





