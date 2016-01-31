using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPubMethods : MonoBehaviour 
{
	[SerializeField] int StartingHealth;
	int healthRemaining;

	[SerializeField] float MaxLight;
	float lightRemaining;

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
		GetHit(40);
	}

	void GetHit(int damage)
	{
		healthRemaining -= damage;
		Debug.Log("Health remaining: " + healthRemaining);

		if(healthRemaining <= 0)
		{
			KillPlayer();
		}
	}

	public int GetCurrentHealth()
	{
		return healthRemaining;
	}

	public void AddLight(float light)
	{
		lightRemaining += light;

		if(lightRemaining > MaxLight)
		{
			lightRemaining = MaxLight;
		}

		if (lightRemaining > MaxLight)
			lightRemaining = MaxLight;

		Debug.Log("Light remaining: " + lightRemaining);

		
	}

	public void RemoveLight(float light)
	{
		lightRemaining -= light;

		if (lightRemaining < 0)
			lightRemaining = 0;

		Debug.Log("Light remaining: " + lightRemaining);
	}

	public float GetCurrentLight()
	{
		return lightRemaining;
	}

	public float GetMaxLight()
	{
		return MaxLight;
	}

	void KillPlayer()
	{

		SceneManager.LoadScene("DeathScreen");
	}
}
