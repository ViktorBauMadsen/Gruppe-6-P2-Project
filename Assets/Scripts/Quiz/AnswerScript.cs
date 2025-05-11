
using System.Collections;
using UnityEngine;

public class AnswerScript : MonoBehaviour // Class to handle answer-related logic.
{
    public bool isCorrect = false; // Boolean to determine if the answer is correct.
    public QuizManager quizManager; // Reference to the QuizManager script.

    public void Answer() // Method called when an answer is selected.
    {
        if (isCorrect) // Check if the selected answer is correct.
        {
            StressValueHolder.singleton.AddStress(18); // Add 18 stress points for a correct answer.

            Debug.Log("Correct"); // Log "Correct" to the console.
            quizManager.Correct(); // Call the Correct() method in QuizManager.
        }
        else // If the answer is incorrect.
        {
            StressValueHolder.singleton.AddStress(28); // Add 28 stress points for an incorrect answer.

            quizManager.StartCoroutine(quizManager.Flash(Color.red)); // Start a coroutine to flash red for incorrect feedback.

            Debug.Log("Wrong"); // Log "Wrong" to the console.
        }
    }
}
