using UnityEngine;

public class YesStackController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Korrekt");
            GameManager.Score++;
            Debug.Log("Current Score: " + GameManager.Score);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Forkert");
            GameManager.angryJudge++;
            Debug.Log("Current Angry: " + GameManager.angryJudge);
        }
    }
}