using UnityEngine;
using System.Collections;

public class Sunbeam : MonoBehaviour {

	public float maxLight;
	public float currentLight;


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
			Destroy(gameObject);
		}
	}
}
