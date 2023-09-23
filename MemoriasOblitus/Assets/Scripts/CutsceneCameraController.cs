using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.Events;

public class CutsceneCameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    private Transform originalPosition;
    private Transform targetObject;
    private Quaternion originalRotation;
    public float moveSpeed = 5f;

    private bool isMoving = false;

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindWithTag("Player");
        originalRotation = mainCamera.transform.rotation;
    }

    public void LookAtTarget(GameObject objectToLook, GameObject lookAtMarker, float cameraSpeed, float waitTime, float delayTime)
    {
        if(!isMoving)
        {
            originalRotation = mainCamera.transform.rotation;
            moveSpeed = cameraSpeed;
            StartCoroutine(MoveCameraToTarget(objectToLook, lookAtMarker, waitTime, delayTime));
        }
    }
    private IEnumerator MoveCameraToTarget(GameObject lookAtObj, GameObject lookAtMarker, float waitTime, float delay)
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
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, lookAtMarker.transform.position, t);
            yield return null;
        }

        StartCoroutine(MoveBack(startTime, cameraToTargetDirection, waitTime, delay, lookAtMarker));
    }

    private IEnumerator MoveBack(float startTime, Vector3 cameraToTargetDirection, float waitReturn, float delay, GameObject lookAtObject)
    {
        yield return new WaitForSeconds(waitReturn);

        lookAtObject.SendMessage("onPlayerInteract", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(delay);

        Vector3 newPosition = targetObject.position - cameraToTargetDirection * 5.0f;

        startTime = Time.time;

        while (Time.time - startTime < 1.0f)
        {
            float t = (Time.time - startTime) * moveSpeed;
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, originalRotation, t);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 0.3f, player.transform.position.z), t);
            yield return null;
        }

        isMoving = false;
    }
}
