using Cinemachine;
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
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float maxJump = 2f;
    private float vertMove = 0f;

    [SerializeField] private float basePov = 60;
    [SerializeField] private float maxPov = 80;
    [SerializeField] private float sensitivityX = 2.0f;
    [SerializeField] private float sensitivityY = 2.0f;

    [SerializeField] private float maxHealth = 8f;
    [SerializeField] private float health;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    public InputActionAsset CharacterActionAsset;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;
    public CinemachineFreeLook FirstPersonCamera;

    public bool isSprinting = false;
    public bool isJumping = false;
    private bool doubleActive = true;

    public bool canMovePlayer;
    public bool canMoveCamera;
    public bool isLanded = false;

    private Vector2 moveValue;
    private Vector2 rotateValue;

    private Vector3 currentRotationAngle;

    public Vector3 respawnPos;

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

        FirstPersonCamera.m_CommonLens = true;

        respawnPos = transform.position;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        canMovePlayer = GameObject.Find("GameManager").GetComponent<GameManager>().cameraNil;
        canMoveCamera = GameObject.Find("GameManager").GetComponent<GameManager>().movmentNil;

        ProcessMove();
        ProcessCamera();

        if(health <= 0)
        {
            health = 0;
        }
    }

    private void ProcessMove()
    {
        if (sprintAction.IsPressed() && characterController.velocity.magnitude > 0)
        {
            FirstPersonCamera.m_Lens.FieldOfView = Mathf.Lerp(FirstPersonCamera.m_Lens.FieldOfView, maxPov, 6f * Time.deltaTime);
            isSprinting = true;
            moveSpeed = Mathf.Lerp(moveSpeed, maxSpeed, 6f * Time.deltaTime);

        }
        else if (!sprintAction.IsPressed() && isSprinting == true)
        {
            FirstPersonCamera.m_Lens.FieldOfView = Mathf.Lerp(FirstPersonCamera.m_Lens.FieldOfView, basePov, 6f * Time.deltaTime);
            moveSpeed = Mathf.Lerp(moveSpeed, baseSpeed, 6f * Time.deltaTime);
            if (FirstPersonCamera.m_Lens.FieldOfView <= basePov && moveSpeed <= baseSpeed)
            {
                isSprinting = false;
            }
        }

        if(FirstPersonCamera.m_Lens.FieldOfView >= maxPov - 0.1)
        {
            FirstPersonCamera.m_Lens.FieldOfView = maxPov;
        }
        else if(FirstPersonCamera.m_Lens.FieldOfView <= basePov + 0.1)
        {
            FirstPersonCamera.m_Lens.FieldOfView = basePov;
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
            FirstPersonCamera.m_Lens.FieldOfView = Mathf.Clamp(FirstPersonCamera.m_Lens.FieldOfView, basePov, maxPov);

            moveValue = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
            Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;

            ProcessVerticalMovement();

            moveDirection.y = vertMove * Time.deltaTime;

            if((moveDirection.y != 0 || moveDirection.x != 0) && OnSlope() && !isJumping) 
            { 
                characterController.Move(Vector3.down * characterController.height / 2 * slopeForce * Time.deltaTime);
            }

            characterController.Move(moveDirection);
        }
    }

    private bool OnSlope()
    {
        if(isJumping) 
        {
            return false;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, characterController.height / 2 * slopeForceRayLength))
        {
            if(hit.normal != Vector3.zero)
            {
                return true;
            }
        }
        return false;
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

        vertMove += (Physics.gravity.y * 1.8f) * Time.deltaTime;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (characterController.isGrounded && hit.transform.tag == "Moving")
        {
            isLanded = true;
            transform.SetParent(hit.transform);
        }
        else
        {
            isLanded = false;
            transform.SetParent(null);
        }
    }

    public void SetRespawn(Vector3 newRespawnPos)
    {
        respawnPos = newRespawnPos;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}