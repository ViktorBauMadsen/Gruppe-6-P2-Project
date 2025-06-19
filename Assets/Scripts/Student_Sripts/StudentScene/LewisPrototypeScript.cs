using UnityEngine;
using UnityEngine.SceneManagement;

public class LewisPrototypeScript : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void LoadSceneByIndex(int zog)
	{
		SceneManager.LoadScene("LewisPrototype");
	}
}
