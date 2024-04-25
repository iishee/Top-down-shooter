using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOver GameOver;

    private void Start()
    {
        // Set the gameOver variable to the GameOver script component attached to the game over screen game object
        GameOver = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is over
        if (IsGameOver())
        {
            // If the game is over and the GameOver variable is not null, show the game over screen
            if (GameOver != null)
            {
                GameOver.ShowGameOverScreen();
            }
        }
    }
    private bool IsGameOver()
    {
        // Find the player game object
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // If the player game object is null, the game is over
        if (player == null)
        {
            return true;
        }

        // Otherwise, the game is not over
        return false;
    }
}