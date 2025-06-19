using UnityEngine;
using UnityEngine.SceneManagement;

public class ShannonPrototypeScript : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void LoadSceneByIndex(int zog)
	{
		SceneManager.LoadScene("ShannonPrototype");
	}
}
