using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int angryJudge = 0;
    public static int Score = 0;
    public GameObject GameOverScreen;
    public GameObject AppealText;
    public TextMeshProUGUI scoreText;
    public GameObject NormalFace;
    public GameObject StartAngryFace;
    public GameObject MidAngryFace;
    public GameObject EndAngryFace;


    void Update()
    {
        if (angryJudge == 3)
        {
            GameOverScreen.SetActive(true);
            scoreText.text = $"Your score was: {Score}";
            AppealText.SetActive(false);
            Time.timeScale = 0;
        }
        if (angryJudge == 0)
        {
            NormalFace.SetActive(true);
        }
        if (angryJudge == 1)
        {
            StartAngryFace.SetActive(true);
            NormalFace.SetActive(false);
        }
        if (angryJudge == 2)
        {
            MidAngryFace.SetActive(true);
            StartAngryFace.SetActive(false);
        }
        if (angryJudge == 3)
        {
            EndAngryFace.SetActive(true);
            MidAngryFace.SetActive(false);
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
    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("codeTestScene");
        GameOverScreen.SetActive(false);
        AppealText.SetActive(true);
        angryJudge = 0;
        Score = 0;
    }



}
