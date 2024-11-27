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
            SceneManager.LoadScene("GameOver");
        }
    }

}
