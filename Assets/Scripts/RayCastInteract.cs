using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastInteract : MonoBehaviour
{ 
    public InputActionAsset characterInputActions;
    public InputAction interactAction;

    public CinemachineFreeLook playerCamera;
    public float distance = 2f;

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

        //UIAnimationManager.Instance.ShowInteractPrompt(false);
        if (Physics.Raycast(interactionRay, out interactionHitInfo, distance) && interactionHitInfo.transform.tag == "Interactable")
        {
            //UIAnimationManager.Instance.ShowInteractPrompt(true);
            if (interactInputPressed)
            {
                interactionHitInfo.transform.SendMessage("onPlayerInteract", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
    }
}
