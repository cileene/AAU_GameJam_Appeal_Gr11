using UnityEngine;

public class YesStackController : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Ja");
            gameManager.IncrementScore();
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Nej");
            gameManager.IncrementAngryJudge();
        }
    }
}