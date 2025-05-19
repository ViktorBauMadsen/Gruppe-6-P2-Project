using TMPro;
using UnityEngine;

public class Dialogue_Assistant : MonoBehaviour // Class to manage dialogue using the TextWriter.
{
    [SerializeField] private TextWriter TextWriter; // Reference to the TextWriter script.
    private TextMeshProUGUI messageText; // Reference to the message text component.
    private AudioSource TalkingAudioSource; // Reference to the audio source for talking sounds.

    private void Awake() // Unity's Awake method, called when the script instance is being loaded.
    {
        if (messageText == null) // Check if the message text reference is null.
        {
            messageText = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>(); // Find and assign the message text component in the hierarchy.
        }
    }

    private void Start() // Unity's Start method, called before the first frame update.
    {
        string originalText = messageText.text; // Store the original text from the message text component.
        if (messageText != null) // Check if the message text component is not null.
        {
            originalText = messageText.text; // Assign the original text.
            messageText.text = string.Empty; // Clear the message text to prepare for typewriter effect.
        }

        if (TextWriter != null && messageText != null) // Check if both the TextWriter and message text are assigned.
        {
            TextWriter.AddWriter(messageText, originalText, 0.025f); // Initialize the TextWriter with the message text, original text, and typing speed.
        }
    }
}
