using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int angryJudge = 0;
    public static int Score = 0;

    void Update()
    {
        if (angryJudge >= 3)
        {
            GameOver();
        }
    }
    public static void GameOver() //TODO: implement game over
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Game Over");
    }
      public static void GameStart()
    {
        SceneManager.LoadScene("GameStart"); //TODO: implement game start
        Debug.Log("Game Start");
    }
}
