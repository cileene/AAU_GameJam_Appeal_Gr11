using UnityEngine;

public class AppealController : MonoBehaviour
{
    private GameObject _player; // Reference to the Player object
    private bool _getAppeal; // Declare the getAppeal variable
    private static bool isCarryingObject;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _getAppeal && !isCarryingObject)
        {
            transform.position = _player.transform.position + new Vector3(0, 1, 0); 
            transform.SetParent(_player.transform); // Set the Player as the parent
            isCarryingObject = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _getAppeal = true;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _getAppeal = false;
        }
    }
}