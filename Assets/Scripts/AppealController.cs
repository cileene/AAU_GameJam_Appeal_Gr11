using UnityEngine;

public class AppealController : MonoBehaviour
{
    private GameObject Player; // Reference to the Player object
    private bool getAppeal; // Declare the getAppeal variable
    private static bool isCarryingObject;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && getAppeal && !isCarryingObject)
        {
            transform.parent = Player.transform; 
            isCarryingObject = true;
        }
    }   

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getAppeal = true;
        }

        if (other.gameObject.CompareTag("yesStack"))
        {
            Destroy(this.gameObject);
            Debug.Log("You have destroyed the object");
            isCarryingObject = false;
        }
        else if (other.gameObject.CompareTag("noStack"))
        {
            Destroy(this.gameObject);
            Debug.Log("You have destroyed the object");
            isCarryingObject = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getAppeal = false;
        }
    }
}