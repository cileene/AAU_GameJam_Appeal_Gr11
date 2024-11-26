using UnityEngine;

public class NoStackController : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager reference is null in OnTriggerEnter!");
            return;
        }

        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Nej");
            gameManager.angryJudge++;
            Debug.Log("Current Angry: " + gameManager.angryJudge);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Ja");
            gameManager.Score++;
            Debug.Log("Current Score: " + gameManager.Score);
        }
    }
}
