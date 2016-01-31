using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
    [SerializeField] GameObject player;
	float dist;

	public AudioClip[] enemyDeathClips;
	public AudioClip[] playerHurtClips;
	public AudioSource enemySounds;



	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public float CheckDist()
    {
        dist = Vector3.Magnitude(transform.position - player.transform.position);
        return dist;
    }

	public void AttackPlayer()
	{
		//Play animation
		player.GetComponent<PlayerPubMethods>().Invoke("BasicAttack", 0.0f);
		PlayPlayerHurt();
	}

	void OnTriggerStay(Collider other)
	{
		if(other.GetComponent<LightBall>())
		{
			PlayDeath ();
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		else if(other.GetComponent<LightBlast>())
		{
			PlayDeath ();
			Destroy(gameObject);
		}
	}

	void PlayDeath()
	{
		int i = Random.Range(0, enemyDeathClips.Length);

		AudioSource.PlayClipAtPoint(enemyDeathClips[i], transform.position);
	}

	void PlayPlayerHurt()
	{
		int i = Random.Range(0, playerHurtClips.Length);
		
		AudioSource.PlayClipAtPoint(playerHurtClips[i], transform.position);
	}
}
