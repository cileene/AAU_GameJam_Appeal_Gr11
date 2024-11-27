using UnityEngine;

public class AppealController : MonoBehaviour
{
    public GameObject Player; // Reference to the Player object
    bool PickKey; // Declare the PickKey variable
    private bool getAppeal; // Declare the getAppeal variable
    private static bool isCarryingObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && getAppeal && !isCarryingObject)
        {
           
            transform.parent = Player.transform; 
            isCarryingObject = true;
        }
    }   

    void OnTriggerEnter(Collider other)
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
        if (other.gameObject.CompareTag("noStack"))
        {
            Destroy(this.gameObject);
            Debug.Log("You have destroyed the object");
            isCarryingObject = false;
        }
 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getAppeal = false;
        }
    }
    

}
