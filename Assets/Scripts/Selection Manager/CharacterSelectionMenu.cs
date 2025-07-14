using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMenu : MonoBehaviour
{
public int numberofPlayers = 2;
public CharacterOption[] characterOptions;
public Transform[] spawnPoints;

private int currentPlayerSelecting = 0;
private int[] selectedCharacterIndices;

 void Start() 
 {
    selectedCharacterIndices = new int[numberofPlayers];
    ShowCharacterOptions();
 }

 void ShowCharacterOptions()
 {
      // Create buttons/icons for each character
        // Add listeners like:
        // button.onClick.AddListener(() => SelectCharacter(i));
 }

 public void SelectedCharacter(int characterIndex)
 {
    if (characterOptions[characterIndex].isTaken) return;

    characterOptions[characterIndex].isTaken = true;
    selectedCharacterIndices[currentPlayerSelecting] = characterIndex;

    currentPlayerSelecting++;

    if (currentPlayerSelecting >= numberofPlayers)
    {
        StartGame();
    }
    else
    {
         // Update UI to show "Player X, pick your character"
    }

 }
 void StartGame()
    {
        for (int i = 0; i < numberofPlayers; i++)
        {
            int characterIndex = selectedCharacterIndices[i];
            Instantiate(characterOptions[characterIndex].characterPrefab, spawnPoints[i].position, Quaternion.identity);
        }

        // Optionally: Load gameplay scene if you're doing scene transition
    }
}
