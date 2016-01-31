using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Chalice : MonoBehaviour {

	public float maxLight;
	public float currentLight;

	public GameObject endTrigger;

	public Light gem;
	public float gemMaxIntensity;

	public GameObject lightbulb;
	public float maxLightAlpha;

	public float a;

	public AudioMixerSnapshot lightOn;
	public AudioMixerSnapshot lightOff;


	
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
		lightOn.TransitionTo(0.5f);

		currentLight += light;

		if(currentLight >= maxLight)
		{
			lightOff.TransitionTo(0.5f);
			OnFilled();
		}

		return true;

	}

	void OnFilled()
	{
		endTrigger.SetActive(true);
	}
}
