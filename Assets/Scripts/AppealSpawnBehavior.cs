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

    private void Start()
    {
        // Initialize text pools
        _appealTexts = new string[][]
        {
            new string[]
            {
                "APPEAL DENIED: Ted Bundy",
                "APPEAL DENIED: The Menendez brothers",
                "APPEAL DENIED: The Zodiac killer",
                "APPEAL DENIED: Jeffrey Dahmer",
                "APPEAL DENIED: The Night Stalker",
                "APPEAL DENIED: John Wayne Gacy",
                "APPEAL DENIED: O.J. Simpson",
                "APPEAL DENIED: Peter Madsen",
                "APPEAL DENIED: The Black Dahlia",
                "APPEAL DENIED: Miranda vs. Arizona",
                "APPEAL DENIED: Roe v. Wade",
                "APPEAL DENIED: Loving v. Virginia",
                "APPEAL DENIED: United States v. Nixon",
                "APPEAL DENIED: McDonald’s Hot Coffee Case",
                "APPEAL DENIED: Too Much Cheese Case",
                "APPEAL DENIED: The Beer and Porn Case",
                "APPEAL DENIED: Batman vs. Batman",
                "APPEAL DENIED: The Peanut Butter Jail Case",
                "APPEAL DENIED: The Weather Channel Case",
                "APPEAL DENIED: Subway Footlong Scandal",
                "APPEAL DENIED: The Beer Belly Case",
                "APPEAL DENIED: The Pop-Tarts Lawsuit",
                "APPEAL DENIED: The Cereal Box Surprise",
                "APPEAL DENIED: A Chimpanzee Goes to Court",
                "APPEAL DENIED: Cow vs. Neighbor",
                "APPEAL DENIED: The Pigeon Poop Case",
                "APPEAL DENIED: The Dungeons & Dragons Ban",
                "APPEAL DENIED: Satan Made Me Do It",
                "APPEAL DENIED: Netflix and Nap",
                "APPEAL DENIED: The Diet Coke Lawsuit",
                "APPEAL DENIED: The Ice Coffee Scandal",
                "APPEAL DENIED: Too Ugly for Work",
                "APPEAL DENIED: The Flying Saucer Agreement"
            }, // Text for prefab 1
            new string[]
            {
                "APPEAL GRANTED: Ted Bundy",
                "APPEAL GRANTED: The Menendez brothers",
                "APPEAL GRANTED: The Zodiac killer",
                "APPEAL GRANTED: Jeffrey Dahmer",
                "APPEAL GRANTED: The Night Stalker",
                "APPEAL GRANTED: John Wayne Gacy",
                "APPEAL GRANTED: O.J. Simpson",
                "APPEAL GRANTED: Peter Madsen",
                "APPEAL GRANTED: The Black Dahlia",
                "APPEAL GRANTED: Miranda vs. Arizona",
                "APPEAL GRANTED: Roe v. Wade",
                "APPEAL GRANTED: Loving v. Virginia",
                "APPEAL GRANTED: United States v. Nixon",
                "APPEAL GRANTED: McDonald’s Hot Coffee Case",
                "APPEAL GRANTED: Too Much Cheese Case",
                "APPEAL GRANTED: The Beer and Porn Case",
                "APPEAL GRANTED: Batman vs. Batman",
                "APPEAL GRANTED: The Peanut Butter Jail Case",
                "APPEAL GRANTED: The Weather Channel Case",
                "APPEAL GRANTED: Subway Footlong Scandal",
                "APPEAL GRANTED: The Beer Belly Case",
                "APPEAL GRANTED: The Pop-Tarts Lawsuit",
                "APPEAL GRANTED: The Cereal Box Surprise",
                "APPEAL GRANTED: A Chimpanzee Goes to Court",
                "APPEAL GRANTED: Cow vs. Neighbor",
                "APPEAL GRANTED: The Pigeon Poop Case",
                "APPEAL GRANTED: The Dungeons & Dragons Ban",
                "APPEAL GRANTED: Satan Made Me Do It",
                "APPEAL GRANTED: Netflix and Nap",
                "APPEAL GRANTED: The Diet Coke Lawsuit",
                "APPEAL GRANTED: The Ice Coffee Scandal",
                "APPEAL GRANTED: Too Ugly for Work",
                "APPEAL GRANTED: The Flying Saucer Agreement"
            } // Text for prefab 2
        };
    }

    private void Update()
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





