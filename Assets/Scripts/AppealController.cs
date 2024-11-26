using UnityEngine;

public class AppealController : MonoBehaviour
{
    public GameObject Player; // Reference to the Player object
    bool PickKey; // Declare the PickKey variable
    private bool getAppeal; // Declare the getAppeal variable

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && getAppeal)
        {
           
            transform.parent = Player.transform; 
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
        }
        if (other.gameObject.CompareTag("noStack"))
        {
            Destroy(this.gameObject);
            Debug.Log("You have destroyed the object");
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
