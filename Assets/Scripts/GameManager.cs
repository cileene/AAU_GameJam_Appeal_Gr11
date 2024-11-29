using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int AngryJudge = 0;
    public static int Score = 0;
    public GameObject gameOverScreen;
    public GameObject appealText;
    public TextMeshProUGUI scoreText;
    public GameObject normalFace;
    public GameObject startAngryFace;
    public GameObject midAngryFace;
    public GameObject endAngryFace;
    public GameObject endCam;
    public GameObject player;

    private void Update()
    {
        if (AngryJudge == 0)
        {
            normalFace.SetActive(true);
        }
        if (AngryJudge == 1)
        {
            startAngryFace.SetActive(true);
            normalFace.SetActive(false);
        }
        if (AngryJudge == 2)
        {
            midAngryFace.SetActive(true);
            startAngryFace.SetActive(false);
        }
        if (AngryJudge == 3)
        {
            player.GetComponent<Rigidbody>().isKinematic = true; //expensive
            
            endCam.SetActive(true);
            endAngryFace.SetActive(true);
            midAngryFace.SetActive(false);
            gameOverScreen.SetActive(true);
            scoreText.text = $"Your score was: {Score}";
            appealText.SetActive(false);
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
        gameOverScreen.SetActive(false);
        appealText.SetActive(true);
        AngryJudge = 0;
        Score = 0;
    }



}
