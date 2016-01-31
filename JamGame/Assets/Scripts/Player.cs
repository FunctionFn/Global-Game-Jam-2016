using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Player : MonoBehaviour {

    public CharacterController controller;
    public GameObject lightballPrefab;
    public GameObject lightblastPrefab;
    public GameObject mainCamera;
	public GameObject staff;
	public Light staffPoint;
	public float staffMaxIntensity;

	public GameObject canvasFlash;

    public Transform lightballSpawnLocation;
    public Transform lightblastSpawnLocation;
    public Transform cameraAxisLocation;

    public Vector3 lookDirectionH;
    public Vector3 lookDirectionV;

    public Vector3 moveDirection;

    public float speed;
    public float jumpSpeed;
    public float airSpeedModifier;

    public float lookSpeedH;
    public float lookSpeedV;

    public float jumpHoldGravityModifier;
    public float gravity;

    public float lightballSpeed;
    public float lightballUpOffset;

    public float lbChargePerSecond;
    public float lbMaxCharge;
	public float lbCost;
	public float blastCost;
    public float currentCharge;
	PlayerSounds playerSounds;
	bool hasJustLanded = false;
	public float lightRechargePerSecond;

	private PlayerPubMethods playerPublicMethods;

	public AudioSource blastSound;
	public AudioSource chargeUp;
	public AudioSource chargeBlast;
	public AudioMixer chargeMixer;
	public AudioMixerSnapshot chargeOn;
	public AudioMixerSnapshot chargeOff;
	bool playCharge = true;

	public AudioMixerSnapshot lightOn;
	public AudioMixerSnapshot lightOff;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        moveDirection = new Vector3(0, 0, 0);

        Physics.IgnoreLayerCollision(8, gameObject.layer);

		playerSounds = GetComponent<PlayerSounds>();
		playerPublicMethods = GetComponent<PlayerPubMethods>();

    }

    // Update is called once per frame
    void Update () 
	{

		if(controller.isGrounded)
		{
			if(!hasJustLanded)
			{
				hasJustLanded = true;
				playerSounds.PlayLand();
			}
		}
		else
		{
			hasJustLanded = false;
		}

        ControlUpdate();

        if (Input.GetButton("Fire"))
        {
            LightballCharge();
        }

        if(Input.GetButtonUp("Fire"))
        {
            Lightball();
        }

        if(Input.GetButtonDown("Blast"))
        {
            LightBlast();
        }

		staffPoint.intensity = staffMaxIntensity * (currentCharge / 100f);

    }

    void ControlUpdate()
    {
        float speedMod = 1;


		if (!controller.isGrounded)
		{
			speedMod = airSpeedModifier;
		}
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * speedMod, moveDirection.y, Input.GetAxis("Vertical"));

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = new Vector3 (moveDirection.x * speed, moveDirection.y, moveDirection.z * speed);

        

        if (controller.isGrounded)
        {

            if (Input.GetButtonDown("Jump"))
			{
                moveDirection.y = jumpSpeed;
				playerSounds.PlayJump();
			}

        }

        if(moveDirection.y > 0 && Input.GetButton("Jump"))
            moveDirection.y -= (gravity - jumpHoldGravityModifier) * Time.deltaTime;
        else
            moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        CameraControl();
    }

    void CameraControl()
    {
        lookDirectionH = new Vector3(0, Input.GetAxis("Horizontal2"), 0);
        transform.Rotate(lookDirectionH * lookSpeedH);


        lookDirectionV = new Vector3(Input.GetAxis("Vertical2"), 0, 0);
        cameraAxisLocation.Rotate(lookDirectionV * lookSpeedV);
        //Debug.Log(cameraAxisLocation.rotation.eulerAngles.x);

        if (cameraAxisLocation.rotation.eulerAngles.x > 270)
        {
            cameraAxisLocation.localEulerAngles = new Vector3(Mathf.Clamp(cameraAxisLocation.rotation.eulerAngles.x, 280, 400), cameraAxisLocation.rotation.y, cameraAxisLocation.rotation.z);
        }
        else
        {
            cameraAxisLocation.localEulerAngles = new Vector3(Mathf.Clamp(cameraAxisLocation.rotation.eulerAngles.x, -10, 80), cameraAxisLocation.rotation.y, cameraAxisLocation.rotation.z);
        }




        /*
        lookDirectionV = Input.GetAxis("Vertical2") * lookSpeedV;
        cameraRotationAxis = rightSide.position - transform.position;
        mainCamera.transform.RotateAround(transform.position, cameraRotationAxis, lookDirectionV);
         */

    }

	//*
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "platformTrigger")
		{

			transform.parent = other.transform.parent.parent;
		}
	}

	void OnTriggerExit(Collider collider)
	{

		if (collider.gameObject.tag == "platformTrigger")
		{
			transform.parent = null;
		}
	}
	//*/



    void Lightball()
    {
        if (currentCharge == lbMaxCharge)
        {
            GameObject go = (GameObject)Instantiate(lightballPrefab, lightballSpawnLocation.position, mainCamera.transform.rotation);
            go.GetComponent<Rigidbody>().velocity = (mainCamera.transform.forward + mainCamera.transform.up * lightballUpOffset) * lightballSpeed;
			if(!chargeBlast.isPlaying)
				chargeBlast.Play();
			SpendLight(lbCost);
        }
		chargeOff.TransitionTo(1f);
		playCharge = true;
        currentCharge = 0;
    }

    void LightballCharge()
    {
		if (playerPublicMethods.GetCurrentLight() >= lbCost)
		{
			if (!chargeUp.isPlaying && playCharge)
			{
				chargeUp.Play();
				playCharge = false;
				chargeOn.TransitionTo(1f);
			}

			currentCharge += lbChargePerSecond * Time.deltaTime;

			if (currentCharge > lbMaxCharge)
			{
				currentCharge = lbMaxCharge;

			}
		}
    }

	void LightBlast()
	{
		if (playerPublicMethods.GetCurrentLight() >= blastCost)
		{
			GameObject go = (GameObject)Instantiate(lightblastPrefab, lightblastSpawnLocation.position, transform.rotation);
			SpendLight(blastCost);

			if(!blastSound.isPlaying)
				blastSound.Play();

			canvasFlash.GetComponent<LightFlash>().Flash();
			iTween.PunchPosition(mainCamera, new Vector3(0, 1.5f, 0), 1.3f);

		}

		
	}

	void ChargeLight()
	{
		lightOn.TransitionTo(1.0f);
		playerPublicMethods.AddLight(lightRechargePerSecond * Time.deltaTime);
	}

	void DrainLight()
	{
		playerPublicMethods.RemoveLight(lightRechargePerSecond * Time.deltaTime);
	}

	void SpendLight(float light)
	{
		lightOn.TransitionTo(1.0f);
		playerPublicMethods.RemoveLight(light);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.GetComponent<Sunbeam>())
		{
			if (playerPublicMethods.GetCurrentLight() < playerPublicMethods.GetMaxLight())
			{
				ChargeLight();
				other.GetComponent<Sunbeam>().drainLight(lightRechargePerSecond * Time.deltaTime);
			}
		}

		if(other.GetComponent<Chalice>())
		{
			if (playerPublicMethods.GetCurrentLight() > 0 && other.GetComponent<Chalice>().AddLight(lightRechargePerSecond * Time.deltaTime))
			{
				DrainLight();
			}
		}
	}

	public bool StolenIsPlayerMoving()
	{
		if (Mathf.Abs(controller.velocity.magnitude) >= .5)
			return true;
		else
			return false;
	}
}
