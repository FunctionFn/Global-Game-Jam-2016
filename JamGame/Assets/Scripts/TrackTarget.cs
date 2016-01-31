using UnityEngine;
using System.Collections;

public class TrackTarget : MonoBehaviour 
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
}
