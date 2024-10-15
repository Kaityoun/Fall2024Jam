using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;  // Singleton instance
    public Text interactPromptText;    // Reference to the Text UI element

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Show the interaction prompt
    public void ShowInteractPrompt(string message)
    {
        interactPromptText.text = message;
        interactPromptText.gameObject.SetActive(true);
    }

    // Hide the interaction prompt
    public void HideInteractPrompt()
    {
        interactPromptText.gameObject.SetActive(false);
    }
}
