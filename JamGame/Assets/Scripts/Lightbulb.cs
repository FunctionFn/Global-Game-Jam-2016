using UnityEngine;
using System.Collections;

public class Lightbulb : MonoBehaviour {


	public float a;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Renderer>().material.color = new Color(255, 255, 255, a);

	}

	public void updateAlpha(float alp)
	{
		a = alp;
	}
}
