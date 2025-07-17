using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterSelectionMenu : MonoBehaviour
{
    private int numberOfPlayers;
    private int currentPlayerSelecting = 0;
    private int[] selectedCharacterIndices;

    public CharacterOption[] characterOptions;

    private Label playerPromptLabel;
    private VisualElement characterContainer;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playerPromptLabel = root.Q<Label>("PlayerPromptLabel");
        characterContainer = root.Q<VisualElement>("CharacterContainer");

        numberOfPlayers = GameSessionManager.Instance.numberOfPlayers;
        selectedCharacterIndices = new int[numberOfPlayers];

        ShowCharacterOptions();
        UpdatePrompt();
    }

    void ShowCharacterOptions()
    {
        characterContainer.Clear();

        for (int i = 0; i < characterOptions.Length+1; i++)
        {
            int index = i;

            var button = new Button(() => SelectCharacter(index))
            {
                text = characterOptions[index].characterName
            };

            if (characterOptions[index].isTaken)
                button.SetEnabled(false);

            characterContainer.Add(button);
        }
    }

    void UpdatePrompt()
    {
        playerPromptLabel.text = $"Player {currentPlayerSelecting + 1}, pick your character";
    }

    void SelectCharacter(int index)
    {
        if (characterOptions[index].isTaken) return;

        characterOptions[index].isTaken = true;
        selectedCharacterIndices[currentPlayerSelecting] = index;
        currentPlayerSelecting++;

        if (currentPlayerSelecting >= numberOfPlayers)
        {
            GameSessionManager.Instance.selectedCharacterIndices = selectedCharacterIndices;
            GameSessionManager.Instance.characterOptions = characterOptions;
            
            SceneManager.LoadScene("LevelSelect");
        }
        else
        {
            ShowCharacterOptions();
            UpdatePrompt();
        }
    }
}
