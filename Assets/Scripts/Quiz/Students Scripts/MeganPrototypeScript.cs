using UnityEngine;
using UnityEngine.SceneManagement;

public class MeganPrototypeScript : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void LoadSceneByIndex(int zog)
	{
		SceneManager.LoadScene("MeganPrototype");
	}
}
