using UnityEngine;
using System.Collections;

public class PlayerPubMethods : MonoBehaviour 
{
	[SerializeField] int StartingHealth;
	int healthRemaning;

	// Use this for initialization
	void Start () 
	{
		healthRemaning = StartingHealth;
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
		healthRemaning -= damage;
		Debug.Log("Health remaining: " + healthRemaning);
	}
}
