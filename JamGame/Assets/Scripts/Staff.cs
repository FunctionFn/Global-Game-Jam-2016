using UnityEngine;
using System.Collections;

public class Staff : MonoBehaviour {

	public float liftHeight;
	public float wobbleWidth;

	public float time;

	public Player player;

	// Use this for initialization
	void Start () {
		iTween.MoveBy(gameObject, iTween.Hash(
			"x", wobbleWidth,
			"y", liftHeight,
			"time", time,
			"looptype", "pingPong",
			"easetype", "easeInOutQuad"));
		iTween.Pause(gameObject);
		//iTween.MoveBy(gameObject, iTween.Hash(
		//	"z", liftHeight,
		//	"time", vTime,
		//	"looptype", "pingPong",
		//	"easetype", "easeInOutQuad"));
	}
	
	// Update is called once per frame
	void Update () {
		if(player.StolenIsPlayerMoving())
		{
			iTween.Resume(gameObject);
		}
		else
		{
			iTween.Pause(gameObject);
		}

	}
}
