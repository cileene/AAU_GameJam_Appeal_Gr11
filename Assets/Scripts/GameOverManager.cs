using UnityEngine;

public class GameOverManager : MonoBehaviour
     
{
    public TextMeshProUGI scoreText;
    public totalScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Score=scoreText;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
