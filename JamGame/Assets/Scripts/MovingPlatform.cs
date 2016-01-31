using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	//Positive or Negative
	[SerializeField] int Direction;
	//Distance forward/backward
	[SerializeField] int XDistance;
	//Distance up/down
	[SerializeField] int YDistance;
	//Distance left/right
	[SerializeField] int ZDistance;
	//Speed
	[SerializeField] int Speed;

	Vector3 initialPos;
	Vector3 targetPos;
	bool forth;
	const float speedCeiling = 1;
	const float speedFloor = 0.05f;

	// Use this for initialization
	void Start () 
	{
		initialPos = transform.position;
		forth = true;
		targetPos = initialPos + (new Vector3(XDistance, YDistance, ZDistance) * Direction);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 moveVect = Vector3.zero;
		if (Mathf.Abs(XDistance) > 0)
		{
			moveVect += new Vector3(1, 0, 0);
		}
		if (Mathf.Abs(YDistance) > 0)
		{
			moveVect += new Vector3(0, 1, 0);
		}
		if (Mathf.Abs(ZDistance) > 0)
		{
			moveVect += new Vector3(0, 0, 1);
		}

		moveVect = Vector3.Normalize(moveVect);

		float speedEase = 0.0f;

		if (forth)
		{
			speedEase = Vector3.Magnitude(transform.position - targetPos) / 2.0f;
		}
		else
		{
			speedEase = Vector3.Magnitude(transform.position - initialPos) / 2.0f;
		}

		if (forth && (Vector3.Magnitude(transform.position - targetPos) <= (Speed / 2)))
		{
			Direction *= -1;
			forth = !forth;
		}

		else if (!forth && (Vector3.Magnitude(transform.position - initialPos) <= (Speed / 2)))
		{
			Direction *= -1;
			forth = !forth;
		}

		transform.position += Direction * moveVect * Speed * Time.deltaTime * Mathf.Lerp(speedFloor, speedCeiling, speedEase);
	}
}
