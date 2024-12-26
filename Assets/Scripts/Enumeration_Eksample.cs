using UnityEngine;

public class Enumeration_Eksample : MonoBehaviour
{
    public enum GameState { MainMenu, Playing, Paused, GameOver } 
    public GameState currentState = GameState.MainMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) currentState = GameState.Playing; 
        else if (Input.GetKeyDown(KeyCode.O)) currentState = GameState.GameOver;

        switch (currentState) // Switch statement to check the current state
        {
            case GameState.MainMenu: Debug.Log("In Main Menu"); break;
            case GameState.Playing: Debug.Log("Playing the game"); break;
            case GameState.Paused: Debug.Log("Game is paused"); break;
            case GameState.GameOver: Debug.Log("Game Over"); break;
        }
    }
}
