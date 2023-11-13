using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        // Attach a method to the button's click event
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // Close the game when the button is clicked
        Application.Quit();
        Debug.Log("Quit");
    }
}
