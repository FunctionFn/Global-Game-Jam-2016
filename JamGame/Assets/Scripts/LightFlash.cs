using UnityEngine;
using System.Collections;

public class LightFlash : MonoBehaviour {

	public float fadePerSecond;

	public CanvasGroup myCG;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(myCG.alpha >= 0)
		{
			myCG.alpha -= fadePerSecond;

			if (myCG.alpha < 0)
				myCG.alpha = 0;
		}
	}

	public void Flash()
	{
		myCG.alpha = 1;
	}
}
