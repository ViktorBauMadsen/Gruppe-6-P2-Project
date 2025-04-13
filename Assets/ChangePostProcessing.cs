using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangePostProcessing : MonoBehaviour
{
	public static ChangePostProcessing singleton;

	private void Awake()
	{
		if (singleton != null)
			Destroy(gameObject);
		else
			singleton = this;

		DontDestroyOnLoad(gameObject);
	}
	public void ChangeParameters(float v, float fg, float b)
    {
        var volume = GetComponent<Volume>().profile;

		// Try to get the vignette effect
		if (volume.TryGet(out Vignette vignette))
		{
			vignette.intensity.value = v; // Adjust intensity
		}

		// Try to get the film grain effect
		if (volume.TryGet(out FilmGrain filmGrain))
		{
			filmGrain.intensity.value = fg; // Adjust film grain intensity
		}

		// Try to get the bloom effect
		if (volume.TryGet(out Bloom bloom))
		{
			bloom.intensity.value = b; // Adjust bloom intensity
		}

		
	}
}
