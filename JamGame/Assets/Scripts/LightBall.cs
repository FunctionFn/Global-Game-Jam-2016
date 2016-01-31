using UnityEngine;
using System.Collections;

public class LightBall : MonoBehaviour {

    public LayerMask whatIsSolid;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {


        if (whatIsSolid.value == (whatIsSolid.value | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject);
        }

    }
}
