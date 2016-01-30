using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public CharacterController controller;
    public GameObject lightballPrefab;
    public GameObject mainCamera;

    public Transform lightballSpawnLocation;
    public Transform cameraAxisLocation;

    public Vector3 lookDirectionH;
    public Vector3 lookDirectionV;

    public Vector3 moveDirection;

    

    public float speed;
    public float jumpSpeed;

    public float lookSpeedH;
    public float lookSpeedV;

    public float gravity;

    public float lightballSpeed;
    public float lightballUpOffset;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        moveDirection = new Vector3(0, 0, 0);

        //Physics.IgnoreLayerCollision(12, gameObject.layer);

    }

    // Update is called once per frame
    void Update () {
        ControlUpdate();
    }

    void ControlUpdate()
    {
        //if (controller.isGrounded)
        //{
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        }

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = new Vector3 (moveDirection.x * speed, moveDirection.y, moveDirection.z * speed);

        

        if (controller.isGrounded)
        {

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
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

    void Lightball()
    {
        GameObject go = (GameObject)Instantiate(lightballPrefab, lightballSpawnLocation.position, mainCamera.transform.rotation);
        go.GetComponent<Rigidbody>().velocity = (mainCamera.transform.forward + mainCamera.transform.up * lightballUpOffset) * lightballSpeed;
    }
}
