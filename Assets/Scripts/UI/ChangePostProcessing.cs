using Unity.VisualScripting; // Provides access to Unity Visual Scripting features (not directly used here)
using UnityEngine; // Provides access to Unity engine features
using UnityEngine.Rendering; // Provides access to rendering features and post-processing
using UnityEngine.Rendering.Universal; // Provides access to Universal Render Pipeline post-processing effects

// This script allows you to change post-processing effects (Vignette, FilmGrain, Bloom) at runtime.
// Attach this script to a GameObject with a Volume component and assign a post-processing profile.
public class ChangePostProcessing : MonoBehaviour
{
    public static ChangePostProcessing singleton; // Singleton instance for global access

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Enforce singleton pattern: if another instance exists, destroy this one
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this; // Set this as the singleton instance

        DontDestroyOnLoad(gameObject); // Persist this object across scene loads
    }

    // Changes the parameters of post-processing effects at runtime
    // v: Vignette intensity, fg: FilmGrain intensity, b: Bloom intensity
    public void ChangeParameters(float v, float fg, float b)
    {
        // Get the VolumeProfile from the attached Volume component
        var volume = GetComponent<Volume>().profile;

        // Try to get the Vignette effect from the profile
        if (volume.TryGet(out Vignette vignette))
        {
            vignette.intensity.value = v; // Set the vignette intensity to the given value
        }

        // Try to get the FilmGrain effect from the profile
        if (volume.TryGet(out FilmGrain filmGrain))
        {
            filmGrain.intensity.value = fg; // Set the film grain intensity to the given value
        }

        // Try to get the Bloom effect from the profile
        if (volume.TryGet(out Bloom bloom))
        {
            bloom.intensity.value = b; // Set the bloom intensity to the given value
        }
    }
}
