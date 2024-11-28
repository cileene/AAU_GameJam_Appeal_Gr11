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
    public GameObject EndCam;
    public GameObject Player;


    void Update()
    {
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
            Player.GetComponent<Rigidbody>().isKinematic = true; //expensive
            
            EndCam.SetActive(true);
            EndAngryFace.SetActive(true);
            MidAngryFace.SetActive(false);
            GameOverScreen.SetActive(true);
            scoreText.text = $"Your score was: {Score}";
            AppealText.SetActive(false);
            //Time.timeScale = 0;
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
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CourtroomScene");
        GameOverScreen.SetActive(false);
        AppealText.SetActive(true);
        angryJudge = 0;
        Score = 0;
    }



}
