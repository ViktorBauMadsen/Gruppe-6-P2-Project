using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart_Button : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void LoadSceneByIndex(int zog)
	{
		SceneManager.LoadScene(zog);
		StressValueHolder.singleton.RemoveStress(StressValueHolder.singleton.StressMeterValue);
	}
}
