using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelSelectionMenu : MonoBehaviour
{
    public LevelData[] levels;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var container = root.Q<VisualElement>("LevelButtons");

        container.Clear();

        foreach (var level in levels)
        {
            var button = new Button(() =>
            {
                GameSessionManager.Instance.currentLevel = level.sceneName;
                SceneManager.LoadScene(level.sceneName);
            });

            button.text = level.displayName;
            container.Add(button);
        }
    }
}
