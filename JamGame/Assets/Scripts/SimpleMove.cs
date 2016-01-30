using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour 
{
    float moveSpeed;

	// Use this for initialization
	void Start () 
    {
        moveSpeed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.W))
        {
            this.transform.position += Time.deltaTime * Vector3.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Time.deltaTime * Vector3.back * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Time.deltaTime * Vector3.left * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Time.deltaTime * Vector3.right * moveSpeed;
        }
	}
}
