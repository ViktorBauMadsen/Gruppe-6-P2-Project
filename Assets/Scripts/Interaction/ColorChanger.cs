using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour, IInteractable
{
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    public string GetDescription()
    {
        return "Change color";
    }

    public void Interact()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);

		StressValueHolder.singleton.RemoveStress(20);
	}
}
