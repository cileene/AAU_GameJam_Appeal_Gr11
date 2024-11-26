using UnityEngine;

public class YesStackController : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Korrekt");
            gameManager.Score++;
            Debug.Log("Current Score: " + gameManager.Score);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Forkert");
            gameManager.angryJudge++;
            Debug.Log("Current Angry: " + gameManager.angryJudge);
        }
    }
}