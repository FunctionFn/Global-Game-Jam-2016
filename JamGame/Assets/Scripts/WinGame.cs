using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Player>())
		{
			SceneManager.LoadScene("Win Screen");
		}
	}
}
