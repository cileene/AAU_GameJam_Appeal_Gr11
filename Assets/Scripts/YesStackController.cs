using UnityEngine;

public class YesStackController : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Ja");
            gameManager.Score++;
            Debug.Log("Current Score: " + gameManager.Score);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Nej");
            gameManager.angryJudge++;
            Debug.Log("Current Angry: " + gameManager.angryJudge);
        }
    }
}