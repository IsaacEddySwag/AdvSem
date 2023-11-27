using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastInteract : MonoBehaviour
{
    [SerializeField] private InputActionAsset characterInputActions;
    [SerializeField] private InputAction interactAction;

    [SerializeField] private CinemachineFreeLook playerCamera;
    [SerializeField] private float distance = 2f;

    [SerializeField] private Animator reticleAnim;

    private void Awake()
    {
        characterInputActions.FindActionMap("Gameplay").Enable();
        interactAction = characterInputActions.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnDisable()
    {
        //Disables the gameplay control scheme from an input action map
        characterInputActions.FindActionMap("Gameplay").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        bool interactInputPressed = interactAction.triggered && interactAction.ReadValue<float>() > 0;

        Ray interactionRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit interactionHitInfo;

        if (Physics.Raycast(interactionRay, out interactionHitInfo, distance) && interactionHitInfo.transform.tag == "Interactable")
        {
            reticleAnim.SetBool("interactable", true);
            if (interactInputPressed)
            {
                interactionHitInfo.transform.SendMessage("onPlayerInteract", SendMessageOptions.DontRequireReceiver);
                Debug.Log($"HIT: {interactionHitInfo.transform.name}");
            }
        }
        else
        {
            reticleAnim.SetBool("interactable", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
    }
}
