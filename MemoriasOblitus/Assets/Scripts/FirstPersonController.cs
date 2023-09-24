using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//Code requires the type of component specified and will create one if one isn't present
[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float maxSpeed = 8f;
    public float baseSpeed = 4f;
    public float maxJump = 1f;
    private float vertMove = 0f;

    public float basePov = 60;
    public float maxPov = 80;

    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;

    public InputActionAsset CharacterActionAsset;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;
    public Camera FirstPersonCamera;

    public bool isSprinting = false;
    public bool isJumping = false;
    private bool doubleActive = true;

    public bool canMovePlayer;
    public bool canMoveCamera;

    private Vector2 moveValue;
    private Vector2 rotateValue;

    private Vector3 currentRotationAngle;

    private void OnEnable()
    {
        //Enables the gameplay control scheme from an input action map
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }

    private void OnDisable()
    {
        //Disables the gameplay control scheme from an input action map
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }

    void Awake()
    {
        //Gets the character control component from the object
        characterController = GetComponent<CharacterController>();

        //Sets the moveAction and rotateAction as the set action map functions
        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotation");
        sprintAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Sprint");
        jumpAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        canMovePlayer = GameObject.Find("GameManager").GetComponent<GameManager>().cameraNil;
        canMoveCamera = GameObject.Find("GameManager").GetComponent<GameManager>().movmentNil;

        ProcessMove();
        ProcessCamera();
    }

    private void ProcessMove()
    {
        if (sprintAction.IsPressed())
        {
            FirstPersonCamera.fieldOfView = Mathf.Lerp(FirstPersonCamera.fieldOfView, maxPov, 6f * Time.deltaTime);
            isSprinting = true;
            moveSpeed = Mathf.Lerp(moveSpeed, maxSpeed, 6f * Time.deltaTime);

        }
        else if (!sprintAction.IsPressed() && isSprinting == true)
        {
            FirstPersonCamera.fieldOfView = Mathf.Lerp(FirstPersonCamera.fieldOfView, basePov, 6f * Time.deltaTime);
            moveSpeed = Mathf.Lerp(moveSpeed, baseSpeed, 6f * Time.deltaTime);
            if (FirstPersonCamera.fieldOfView <= basePov && moveSpeed <= baseSpeed)
            {
                isSprinting = false;
            }
        }

        if(FirstPersonCamera.fieldOfView >= maxPov - 0.1)
        {
            FirstPersonCamera.fieldOfView = 80;
        }
        else if(FirstPersonCamera.fieldOfView <= basePov + 0.1)
        {
            FirstPersonCamera.fieldOfView = 60;
        }

        if(moveSpeed >= maxSpeed - 0.1)
        {
            moveSpeed = maxSpeed;
        }
        else if(moveSpeed <= baseSpeed + 0.1)
        {
            moveSpeed = baseSpeed;
        }

        if(canMovePlayer == false) 
        {
            FirstPersonCamera.fieldOfView = Mathf.Clamp(FirstPersonCamera.fieldOfView, basePov, maxPov);

            moveValue = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
            Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;

            ProcessVerticalMovement();

            moveDirection.y = vertMove * Time.deltaTime;

            characterController.Move(moveDirection);
        }
    }

    private void ProcessCamera()
    {
        float rotationX = rotateValue.y * sensitivityY;
        float rotationY = rotateValue.x * sensitivityX;

        //Sets moveValue to read the inputs and translates it into an x and y value in a Vector2
        if(canMoveCamera == false) 
        {
            rotateValue = rotateAction.ReadValue<Vector2>() * Time.deltaTime;

            currentRotationAngle = new Vector3(currentRotationAngle.x - rotationX, currentRotationAngle.y + rotationY, 0);

            currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

            FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
        }
    }

    private void ProcessVerticalMovement()
    {
        if (characterController.isGrounded)
        {
            doubleActive = true;
            isJumping = false;
        }

        if (characterController.isGrounded && vertMove < 0)
        {
            vertMove = 0;
        }

        bool jumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;

        if (jumpButtonDown && (characterController.isGrounded || doubleActive) && canMovePlayer == false)
        {
            vertMove += Mathf.Sqrt(maxJump * -2.0f * Physics.gravity.y);
            doubleActive = false;
            isJumping = true;
        }

        vertMove += Physics.gravity.y * Time.deltaTime;
    }
}