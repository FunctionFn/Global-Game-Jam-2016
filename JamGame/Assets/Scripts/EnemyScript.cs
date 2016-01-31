using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
    [SerializeField] GameObject player;
	float dist;

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
	}
}
