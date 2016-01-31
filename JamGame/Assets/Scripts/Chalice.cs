using UnityEngine;
using System.Collections;

public class Chalice : MonoBehaviour {

	public float maxLight;
	public float currentLight;

	public Light gem;
	public float gemMaxIntensity;

	public GameObject lightbulb;
	public float maxLightAlpha;

	public float a;


	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gem.intensity = gemMaxIntensity * (currentLight / maxLight);
		a = maxLightAlpha * (currentLight / maxLight);
		lightbulb.GetComponent<Lightbulb>().updateAlpha(a);
	}

	public bool AddLight(float light)
	{
		if (currentLight >= maxLight)
			return false;


		currentLight += light;

		if(currentLight >= maxLight)
		{
			OnFilled();
		}

		return true;

	}

	void OnFilled()
	{
		Debug.Log("Door Open!");
	}
}
