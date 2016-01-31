using UnityEngine;
using System.Collections;

public class PlayerPubMethods : MonoBehaviour 
{
	[SerializeField] int StartingHealth;
	int healthRemaining;

	[SerializeField] int StartingLight;
	int lightRemaining;

	// Use this for initialization
	void Start () 
	{
		healthRemaining = StartingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void BasicAttack()
	{
		GetHit(10);
	}

	void GetHit(int damage)
	{
		healthRemaining -= damage;
		Debug.Log("Health remaining: " + healthRemaining);
	}

	void AddLight(int light)
	{
		lightRemaining += light;
		Debug.Log("Light remaining: " + lightRemaining);
	}

	void RemoveLight(int light)
	{
		lightRemaining += light;
		Debug.Log("Light remaining: " + lightRemaining);
	}
}
