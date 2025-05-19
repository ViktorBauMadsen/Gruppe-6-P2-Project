using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour // Class to handle typewriter-style text display.
{
    private TextMeshProUGUI uiText; // Reference to the UI text component.
    private string textToWrite; // The full text to display.
    private int characterIndex; // Index of the current character being displayed.
    private float timePerCharacter; // Time interval between displaying each character.
    private float timer; // Timer to track the time elapsed.
    public GameObject TalkingSound; // Reference to the GameObject for talking sound.

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter) // Method to initialize the text writer.
    {
        this.uiText = uiText; // Assign the UI text component.
        this.textToWrite = textToWrite; // Assign the text to write.
        this.timePerCharacter = timePerCharacter; // Assign the time interval per character.
        characterIndex = 0; // Reset the character index to start from the beginning.
    }

    private void Update() // Unity's Update method, called once per frame.
    {
        if (uiText != null) // Check if there is text to display.
        {
            timer -= Time.deltaTime; // Decrease the timer by the time elapsed since the last frame.
            while (timer <= 0f) // While the timer is less than or equal to zero.
            {
                timer += timePerCharacter; // Reset the timer for the next character.
                characterIndex++; // Move to the next character.
                uiText.text = textToWrite.Substring(0, characterIndex); // Update the UI text to show the current portion of the text.

                if (characterIndex >= textToWrite.Length) // Check if all characters have been displayed.
                {
                    uiText = null; // Stop updating the text.
                    return; // Exit the method.
                }
            }
        }
        else // If there is no text to display.
        {
            TalkingSound.SetActive(false); // Deactivate the talking sound GameObject.
        }
    }
}
