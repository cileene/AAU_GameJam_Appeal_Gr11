using UnityEngine;
/*
public class YesStackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    // Checks if the appeal that collides with the no stack is tagged as "AppealYes" or "AppealNo"
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            GameManager.Score++;
            // If the player collides into yesStack with the correct appeal tagged as "AppealYes" the score will increment by 1
        }
        else if (other.gameObject.CompareTag("AppealNo"))
        {
            GameManager.AngryJudge++;
            // If the player collides into yesStack with the wrong appeal tagged as "AppealNo" the AngryJudge will increment by 1
        }
    }
}




public class YesStackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AppealController appealController = other.GetComponent<AppealController>();
        if (AppealYes)
        {
            GameManager.Score++;
        }
        else if (AppealNo)
        {
            GameManager.AngryJudge++;
        }
    }
}*/