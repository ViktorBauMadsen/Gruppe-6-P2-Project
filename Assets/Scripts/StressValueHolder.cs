using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StressValueHolder : MonoBehaviour
{
	public static StressValueHolder singleton;

	public float StressMeterValue_Max = 100;
	public float StressMeterValue;

	public Slider StressMeterSlider;

	private void Awake()
	{
		if (singleton != null)
			Destroy(gameObject);
		else
			singleton = this;

		DontDestroyOnLoad(gameObject);
	}
	private void OnValidate()
	{
		UpdateMeterValue();
	}
	public void RemoveStress(float stressRemoval)
	{
		StressMeterValue -= stressRemoval;
		UpdateMeterValue();
	}
	public void AddStress(float stressAddition)
	{
		StressMeterValue += stressAddition;
		UpdateMeterValue();
	}
	public void UpdateMeterValue()
	{
		StressMeterValue = Mathf.Clamp(StressMeterValue, 0, StressMeterValue_Max); //den tager en tal, den må ikke kommer under "0", den må ikke kommer over SMV_MAX.
		StressMeterSlider.value = StressMeterValue / StressMeterValue_Max;

		ProcessingCheck();

		DeathCheck();
	}
	private void ProcessingCheck()
	{
		ChangePostProcessing.singleton.ChangeParameters(StressMeterValue / 250, StressMeterValue / 10, StressMeterValue / 2);
	}


	private void DeathCheck()
	{
		if (StressMeterValue >= StressMeterValue_Max)
		{
			SceneManager.LoadScene("DeathScreen");
		}
	}
}
