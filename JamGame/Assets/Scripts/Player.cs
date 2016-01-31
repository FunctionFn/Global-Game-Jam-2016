using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public CharacterController controller;
    public GameObject lightballPrefab;
    public GameObject lightblastPrefab;
    public GameObject mainCamera;

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


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        moveDirection = new Vector3(0, 0, 0);

        Physics.IgnoreLayerCollision(8, gameObject.layer);

		playerSounds = GetComponent<PlayerSounds>();
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
		Debug.Log("Enter trigger");

		if (other.tag == "platformTrigger")
		{
			Debug.Log("Entered correct trigger");

			transform.parent = other.transform.parent.parent;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		Debug.Log("Exit trigger");

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
        }
        currentCharge = 0;
    }

    void LightballCharge()
    {
        currentCharge += lbChargePerSecond * Time.deltaTime;

        if(currentCharge > lbMaxCharge)
        {
            currentCharge = lbMaxCharge;
        }

    }

	void LightBlast()
	{
		GameObject go = (GameObject)Instantiate(lightblastPrefab, lightblastSpawnLocation.position, transform.rotation);
	}

	void ChargeLight()
	{
		gameObject.GetComponent<PlayerPubMethods>().AddLight(lightRechargePerSecond);
	}
}
