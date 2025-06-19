using UnityEngine;

public class OneSecondSM : MonoBehaviour
{
	
	private float timer = 0f;
	public float interval = 1f; // How often (in seconds) something should happen

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= interval)
		{
			StressValueHolder.singleton.AddStress(2);
			timer = 0f;
		}
	}
}
