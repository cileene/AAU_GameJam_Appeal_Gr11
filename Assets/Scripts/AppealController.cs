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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getAppeal = false;
        }
    }
}
