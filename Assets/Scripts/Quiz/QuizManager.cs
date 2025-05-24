using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour // Class to manage the quiz logic.
{
    public List<QuestionsAndAnswers> QnA; // List of questions and answers.
    public GameObject[] options; // Array of answer option GameObjects.
    public int currentQuestion; // Index of the current question.

    public Image FeedbackColor; // UI Image to display feedback color.
    public float FlashDuration = 0.2f; // Duration of the feedback flash.

    public TextMeshProUGUI QuestionTxt; // TextMeshProUGUI component to display the question text.

    private void Start() // Unity's Start method, called before the first frame update.
    {
        Cursor.visible = true; // Make the cursor visible.

        if (QnA.Count > 0) // Check if there are questions in the QnA list.
        {
            GenerateQuestion(); // Generate the first question.
        }
        else // If no questions are available.
        {
            Debug.LogError("No questions available in the QnA list."); // Log an error message.
        }
    }

    public void Correct() // Method called when the correct answer is selected.
    {
        if (QnA.Count > 0) // Check if there are questions remaining.
        {
            StartCoroutine(Flash(Color.green)); // Start a coroutine to flash green for correct feedback.

            QnA.RemoveAt(currentQuestion); // Remove the current question from the list.
            if (QnA.Count > 0) // Check if there are more questions left.
            {
                GenerateQuestion(); // Generate the next question.
            }
            else // If no more questions are available.
            {
                Debug.Log("No more questions available."); // Log a message.

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene.
            }
        }
    }

    public void Wrong() // Method called when the wrong answer is selected.
    {
        StartCoroutine(Flash(Color.red)); // Start a coroutine to flash red for incorrect feedback.
    }

    public IEnumerator Flash(Color color) // Coroutine to flash a feedback color.
    {
        FeedbackColor.color = new Color(color.r, color.g, color.b, 0.3f); // Set the feedback color to semi-transparent.
        yield return new WaitForSeconds(FlashDuration); // Wait for the specified flash duration.
        FeedbackColor.color = new Color(color.r, color.g, color.b, 0f); // Reset the feedback color to fully transparent.
    }

    void SetAnswers() // Method to set the answer options for the current question.
    {
        Debug.Log("Setting answers for the current question."); // Log a message.

        if (QnA[currentQuestion].Answers.Length != options.Length) // Check if the number of answers matches the number of options.
        {
            Debug.LogError($"The number of answers ({QnA[currentQuestion].Answers.Length}) does not match the number of options ({options.Length}) for question: {QnA[currentQuestion].Questions}"); // Log an error message.
            return; // Exit the method.
        }

        for (int i = 0; i < options.Length; i++) // Loop through each option.
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false; // Set all options to incorrect by default.
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i]; // Set the text of the option to the corresponding answer.
            Debug.Log($"Setting option {i} text to: {QnA[currentQuestion].Answers[i]}"); // Log the option text.

            if (QnA[currentQuestion].CorrectAnswer == i) // Check if the current option is the correct answer.
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true; // Mark the option as correct.
            }
        }
    }

    void GenerateQuestion() // Method to generate a new question.
    {
        if (QnA.Count > 0) // Check if there are questions remaining.
        {
            currentQuestion = Random.Range(0, QnA.Count); // Select a random question index.
            QuestionTxt.text = QnA[currentQuestion].Questions; // Set the question text.
            Debug.Log($"Generating question: {QnA[currentQuestion].Questions} with {QnA[currentQuestion].Answers.Length} answers."); // Log the question and number of answers.
            SetAnswers(); // Set the answer options for the question.
        }
        else // If no more questions are available.
        {
            Debug.Log("No more questions available."); // Log a message.
        }
    }
}
