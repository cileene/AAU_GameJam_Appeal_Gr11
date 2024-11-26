using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int angryJudge = 0;
    public int Score = 0;

    public void IncrementAngryJudge()
    {
        angryJudge++;
        Debug.Log("Current Angry: " + angryJudge);
    }

    public void IncrementScore()
    {
        Score++;
        Debug.Log("Current Score: " + Score);
    }
}