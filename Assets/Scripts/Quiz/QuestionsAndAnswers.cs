using UnityEngine;
[System.Serializable]
public class QuestionsAndAnswers // Class to store questions and their corresponding answers.
{
    public string Questions; // The question text.
    public string[] Answers; // Array of possible answers for the question.
    public int CorrectAnswer; // Index of the correct answer in the Answers array.
}
