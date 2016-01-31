using UnityEngine;
using System.Collections;

public class PlayerPubMethods : MonoBehaviour 
{
	[SerializeField] int StartingHealth;
	int healthRemaining;

	[SerializeField] float StartingLight;
	float lightRemaining;

	// Use this for initialization
	void Start () 
	{
		healthRemaining = StartingHealth;
		lightRemaining = StartingLight;
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

	public void AddLight(float light)
	{
		lightRemaining += light;
		Debug.Log("Light remaining: " + lightRemaining);
	}

	public void RemoveLight(float light)
	{
		lightRemaining += light;
		Debug.Log("Light remaining: " + lightRemaining);
	}
}
