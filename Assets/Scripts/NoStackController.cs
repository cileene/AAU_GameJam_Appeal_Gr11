using UnityEngine;

public class NoStackController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Forkert");
            GameManager.angryJudge++;
            Debug.Log("Current Angry: " + GameManager.angryJudge);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Korrekt");
            GameManager.Score++;
            Debug.Log("Current Score: " + GameManager.Score);
        }
    }
}
