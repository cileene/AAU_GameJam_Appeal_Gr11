using UnityEngine;

public class YesStackController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
      void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AppealYes"))
        {
            Debug.Log("Ja");
        }
        if (other.gameObject.CompareTag("AppealNo"))
        {
            Debug.Log("Nej");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
