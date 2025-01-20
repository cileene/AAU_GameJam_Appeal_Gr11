using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// This script is used to manage the game state and the game over screen
public class GameManager : MonoBehaviour
{
    // static variables are shared across all instances of a class they cannot be changed
    public static int AngryJudge = 0;
    public static int Score = 0;

    // public variables are accessible from the inspector and from other scripts (used for example in the ScoringSystem script)
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
            player.GetComponent<Rigidbody>().isKinematic = true;
            
            endCam.SetActive(true);
            endAngryFace.SetActive(true);
            midAngryFace.SetActive(false);
            gameOverScreen.SetActive(true);
            scoreText.text = $"Your score was: {Score}";
            appealText.SetActive(false);
        }
    }
      
    public void RestartGame() // method is not called in the script but as "OnClick" of restart button in the inspector
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CourtroomScene");
        gameOverScreen.SetActive(false);
        appealText.SetActive(true);
        AngryJudge = 0;
        Score = 0;
    }
}


//EXAMPLE OF A SWITCH STATEMENT INSTEAD OF THE IF STATEMENTS, CAN IMPORVE READABILITY
/*private void Update()
{
    switch (AngryJudge)
    {
        case 0:
            normalFace.SetActive(true);
            startAngryFace.SetActive(false);
            midAngryFace.SetActive(false);
            endAngryFace.SetActive(false);
            break;
        case 1:
            normalFace.SetActive(false);
            startAngryFace.SetActive(true);
            midAngryFace.SetActive(false);
            endAngryFace.SetActive(false);
            break;
        case 2:
            normalFace.SetActive(false);
            startAngryFace.SetActive(false);
            midAngryFace.SetActive(true);
            endAngryFace.SetActive(false);
            break;
        case 3:
            player.GetComponent<Rigidbody>().isKinematic = true; //expensive
            normalFace.SetActive(false);
            startAngryFace.SetActive(false);
            midAngryFace.SetActive(false);
            endAngryFace.SetActive(true);
            endCam.SetActive(true);
            gameOverScreen.SetActive(true);
            scoreText.text = $"Your score was: {Score}";
            appealText.SetActive(false);
            //Time.timeScale = 0;
            break;
        default:
            Debug.LogWarning("Unexpected AngryJudge value: " + AngryJudge);
            break;
    }
}*/