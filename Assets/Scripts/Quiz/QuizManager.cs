using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Image FeedbackColor;
    public float FlashDuration = 0.2f;

	public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
		Cursor.visible = true;

        if (QnA.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            Debug.LogError("No questions available in the QnA list.");
        }
    }

    public void Correct()
    {
        if (QnA.Count > 0)
        {
			StartCoroutine(Flash(Color.green));

			QnA.RemoveAt(currentQuestion);
            if (QnA.Count > 0)
            {
				GenerateQuestion();
			}
            else
            {
                Debug.Log("No more questions available.");

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
	public void Wrong()
	{
		StartCoroutine(Flash(Color.red)); // for wrong answers
	}

	public IEnumerator Flash(Color color)
	{
		FeedbackColor.color = new Color(color.r, color.g, color.b, 0.3f); // not-transparent
		yield return new WaitForSeconds(FlashDuration);
		FeedbackColor.color = new Color(color.r, color.g, color.b, 0f); // fade back to transparent
	}

	void SetAnswers()
    {
        Debug.Log("Setting answers for the current question.");
        if (QnA[currentQuestion].Answers.Length != options.Length)
        {
            Debug.LogError($"The number of answers ({QnA[currentQuestion].Answers.Length}) does not match the number of options ({options.Length}) for question: {QnA[currentQuestion].Questions}");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            Debug.Log($"Setting option {i} text to: {QnA[currentQuestion].Answers[i]}");

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Questions;
            Debug.Log($"Generating question: {QnA[currentQuestion].Questions} with {QnA[currentQuestion].Answers.Length} answers.");
            SetAnswers();
        }
        else
        {
            Debug.Log("No more questions available.");
        }
    }
}
