using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class CutsceneCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public float waitTime = 2f;

    private void Start()
    {
        // Disable the virtual camera at the beginning
        virtualCamera.gameObject.SetActive(false);
    }

    public void LookAtObjectAndReturn(GameObject objectLook)
    {
        // Enable the virtual camera and set the Look At target
        virtualCamera.gameObject.SetActive(true);
        virtualCamera.LookAt = objectLook.transform;

        // You can also set other properties like the Field of View here

        // To return to the original position, you might use a coroutine or a timer
        StartCoroutine(ReturnToOriginalPosition());
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        yield return new WaitForSeconds(waitTime); // Adjust the time as needed

        // Reset the Look At target and disable the virtual camera
        virtualCamera.LookAt = null;
        virtualCamera.gameObject.SetActive(false);
    }
}