
using UnityEngine;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect= false;
    public QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
			StressValueHolder.singleton.AddStress(10);

			Debug.Log("Correct");
            quizManager.Correct();
        }
        else
        {
			StressValueHolder.singleton.AddStress(30);

			Debug.Log("Wrong");
        }
    }

}
