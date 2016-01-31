using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Sunbeam : MonoBehaviour {

	public float maxLight;
	public float currentLight;

	public AudioMixerSnapshot lightOff;

	void Start()
	{
		currentLight = maxLight;
	}

	public void drainLight(float light)
	{
		currentLight -= light;
	}

	void Update()
	{
		if (currentLight <= 0)
		{
			lightOff.TransitionTo(10f);
			Destroy(gameObject);
		}
	}
}
