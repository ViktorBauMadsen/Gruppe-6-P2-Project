
using System.Collections;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    
    public bool isCorrect= false;
    public QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
			StressValueHolder.singleton.AddStress(18);

			Debug.Log("Correct");
            quizManager.Correct();
        }
        else
        {
			StressValueHolder.singleton.AddStress(28);

			quizManager.StartCoroutine(quizManager.Flash(Color.red));
			
            Debug.Log("Wrong");
        }
    }
}
