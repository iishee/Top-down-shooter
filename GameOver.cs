using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "Points";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ShowGameOverScreen()
    {
        // Enable the game object that the script is attached to
        gameObject.SetActive(true);
    }
}