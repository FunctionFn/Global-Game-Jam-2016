using UnityEngine;
using System.Collections;

public class LightBlast : MonoBehaviour {

    public float expansionSpeed;
    public float lifetime;

    public float life;


	// Use this for initialization
	void Start () {
        life = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(expansionSpeed * Time.deltaTime, expansionSpeed * Time.deltaTime, expansionSpeed * Time.deltaTime);

        life -= Time.deltaTime;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
	}
}
