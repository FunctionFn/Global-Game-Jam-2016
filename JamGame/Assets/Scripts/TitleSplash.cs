﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSplash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("Level 1");
		}
	}
}
