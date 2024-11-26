using UnityEngine;

public class NoStackController : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Forkert");
            gameManager.angryJudge++;
            Debug.Log("Current Angry: " + gameManager.angryJudge);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Korrekt");
            gameManager.Score++;
            Debug.Log("Current Score: " + gameManager.Score);
        }
    }
}
