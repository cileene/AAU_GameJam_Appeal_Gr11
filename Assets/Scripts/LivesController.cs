using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public GameObject lifeIconPrefab; // Prefab for the life icon
    public Transform livesContainer; // Container for the life icons

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesDisplay();
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLivesDisplay();
        }
    }

    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLivesDisplay();
        }
    }

    private void UpdateLivesDisplay()
    {
        
        foreach (Transform child in livesContainer) // Clear existing life icons
        {
            Destroy(child.gameObject);
        }

        
        for (int i = 0; i < currentLives; i++) // Instantiate life icons
        {
            Instantiate(lifeIconPrefab, livesContainer);
        }
    }
}
