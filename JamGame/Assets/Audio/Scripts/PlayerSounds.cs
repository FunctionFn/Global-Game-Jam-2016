using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

	public AudioSource footstepSound;
	public AudioSource jumpSound;
	public AudioSource landSound;

	public AudioClip[] landClips;
	public AudioClip[] jumpClips;
	public AudioClip[] footstepClips;

	public CharacterController controller;

	bool playsteps = false;

	public float walkInterval = 10f;

	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (IsPlayerMoving())
		{
			playsteps = true;
			StartCoroutine ("PlayFootsteps");
		}	
	
	}

	public void PlayJump()
	{
		if(!jumpSound.isPlaying)
		{
			int i = Random.Range (0, jumpClips.Length);
			
			float p = Random.Range (.95f, 1.3f);
			float v = Random.Range (.3f, .6f);
			
			jumpSound.pitch = p;
			jumpSound.volume = v;
			
			jumpSound.PlayOneShot(jumpClips[i]);
		}
	}

	public void PlayLand()
	{
		if(!landSound.isPlaying)
		{
			int i = Random.Range (0, landClips.Length);
			
			float p = Random.Range (.95f, 1.3f);
			float v = Random.Range (.3f, .6f);
			
			landSound.pitch = p;
			landSound.volume = v;

			landSound.PlayOneShot(landClips[i]);
		}

	}
	
	bool IsPlayerMoving()
	{
		if (controller.isGrounded && !playsteps && Mathf.Abs (controller.velocity.magnitude) >= .5) 
			return true;
		else
			return false;
	}

	IEnumerator PlayFootsteps() 
	{	

			int i = Random.Range (0, footstepClips.Length);
			
			float p = Random.Range (.95f, 1.3f);
			float v = Random.Range (.3f, .6f);
			
			footstepSound.pitch = p;
			footstepSound.volume = v;
			
			// Make sure same footstep clip isn't played twice in a row
			if (footstepSound.clip != footstepClips [i])
				footstepSound.clip = footstepClips [i];
			else
				footstepSound.clip = footstepClips [i / 2];

			footstepSound.PlayOneShot (footstepSound.clip);

			yield return new WaitForSeconds(walkInterval);
			playsteps = false;
	}

}
