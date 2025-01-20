using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public enum StackType
    {
        YesStack,
        NoStack
    }

    public StackType stackType; // for reference to scoring system

    private void OnTriggerEnter(Collider other)
    {
        AppealController appealController = other.GetComponent<AppealController>();
        if (appealController != null)
        {
            if (stackType == StackType.YesStack)
            {
                if (appealController.appealType == AppealController.AppealType.AppealYes)
                {
                    GameManager.Score++;
                    Debug.Log("Correct: Score incremented");
                }
                else if (appealController.appealType == AppealController.AppealType.AppealNo)
                {
                    GameManager.AngryJudge++;
                    Debug.Log("Wrong: AngryJudge incremented");
                }
            }
            else if (stackType == StackType.NoStack)
            {
                if (appealController.appealType == AppealController.AppealType.AppealNo)
                {
                    GameManager.Score++;
                    Debug.Log("Correct: Score incremented");
                }
                else if (appealController.appealType == AppealController.AppealType.AppealYes)
                {
                    GameManager.AngryJudge++;
                    Debug.Log("Wrong: AngryJudge incremented");
                }
            }
        }
    }
}