using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GlobalSave : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
