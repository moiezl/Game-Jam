using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager Instance;

    public int numberOfPlayers;
    public int[] selectedCharacterIndices;
    public CharacterOption[] characterOptions;
    public List<string> selectedLevelNames = new();
    public string currentLevel;
    public int currentLevelIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetCurrentLevel() => selectedLevelNames[currentLevelIndex];
    public bool HasMoreLevels() => currentLevelIndex + 1 < selectedLevelNames.Count;

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(GetCurrentLevel());
    }
}
