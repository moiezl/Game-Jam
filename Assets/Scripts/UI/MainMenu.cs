using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    private void OnEnable()
    {
        // Get the root of the UIDocument
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Grab buttons by name
        var startButton = root.Q<Button>("StartButton");
        var quitButton = root.Q<Button>("QuitButton");

        // Assign click events
        startButton.clicked += StartGame;
        quitButton.clicked += QuitGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene("PlayerCount"); // Replace with your actual game scene
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button clicked."); // This won't quit the editor
    }
}
