using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerCount : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var buttonsContainer = root.Q<VisualElement>("PlayerCountButtons");

        for (int i = 2; i <= 4; i++) // supports 2–4 players
        {
            int count = i;
            var button = new Button(() =>
            {
                Debug.Log("Loading CharacterSelect...");
                GameSessionManager.Instance.numberOfPlayers = count;
                SceneManager.LoadScene(2);
            });

            button.text = count + " Players";
            buttonsContainer.Add(button);
        }
    }
}
