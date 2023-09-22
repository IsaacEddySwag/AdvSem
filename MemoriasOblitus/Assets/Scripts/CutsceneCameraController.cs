using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class CutsceneCameraController : MonoBehaviour
{
    public Camera mainCamera;
    private Transform originalPosition;
    private Transform targetObject;
    public float moveSpeed = 5.0f;

    private bool isMoving = false;

    private void Start()
    {
        mainCamera = Camera.main;
        originalPosition = mainCamera.transform;
    }

    public void LookAtTarget(GameObject objectToLook)
    {
        if(!isMoving)
        {
            StartCoroutine(MoveCameraToTarget(objectToLook));
        }
    }
    private IEnumerator MoveCameraToTarget(GameObject lookAtObj)
    {
        targetObject = lookAtObj.transform;

         isMoving = true;

        Vector3 cameraToTargetDirection = (targetObject.position - mainCamera.transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(cameraToTargetDirection);
        float startTime = Time.time;

        while (Time.time - startTime < 1.0f) 
        {
            float t = (Time.time - startTime) * moveSpeed;
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRotation, t);
            yield return null;
        }

        Vector3 newPosition = targetObject.position - cameraToTargetDirection * 5.0f; 

        startTime = Time.time;

        while (Time.time - startTime < 1.0f) 
        {
            float t = (Time.time - startTime) * moveSpeed;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPosition, t);
            yield return null;
        }

        isMoving = false;
    }
}
