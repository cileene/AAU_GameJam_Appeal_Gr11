using UnityEngine;

public class YesStackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Correct");
            GameManager.Score++;
            Debug.Log("Current Score: " + GameManager.Score);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Wrong");
            GameManager.AngryJudge++;
            Debug.Log("Current Angry: " + GameManager.AngryJudge);
        }
    }
}