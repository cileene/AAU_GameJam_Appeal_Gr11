using UnityEngine;

public class NoStackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Wrong");
            GameManager.AngryJudge++;
            Debug.Log("Current Angry: " + GameManager.AngryJudge);
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Correct");
            GameManager.Score++;
            Debug.Log("Current Score: " + GameManager.Score);
        }
    }
}
