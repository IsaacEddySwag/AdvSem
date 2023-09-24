using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class CutsceneCameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    private Transform originalPosition;
    private Transform targetObject;
    private Quaternion originalRotation;
    public float moveSpeed = 5f;

    public GameObject objectToLook;
    public GameObject lookAtMarker;

    public float cameraSpeed;
    public float waitTime;
    public float delayTime;

    private bool isMoving = false;

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindWithTag("Player");
        originalRotation = mainCamera.transform.rotation;
    }

    public void LookAtTarget()
    {
        if (!isMoving)
        {
            originalRotation = mainCamera.transform.rotation;
            moveSpeed = cameraSpeed;
            StartCoroutine(MoveCameraToTarget());
        }
    }
    private IEnumerator MoveCameraToTarget()
    {
        targetObject = objectToLook.transform;

        isMoving = true;
        GameObject.Find("GameManager").GetComponent<GameManager>().cameraNil = true;
        GameObject.Find("GameManager").GetComponent<GameManager>().movmentNil = true;

        Vector3 cameraToTargetDirection = (targetObject.position - mainCamera.transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(cameraToTargetDirection);

        float startTime = Time.time;

        while (Time.time - startTime < 1.0f) 
        {
            float t = (Time.time - startTime) * moveSpeed;
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRotation, t);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, objectToLook.transform.position, t);
            cameraToTargetDirection = (targetObject.position - mainCamera.transform.position).normalized;
            yield return null;
        }
        
        yield return new WaitForSeconds(waitTime);
        
        lookAtMarker.SendMessage("onPlayerInteract", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(delayTime);

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
        GameObject.Find("GameManager").GetComponent<GameManager>().cameraNil = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().movmentNil = false;
    }

    public void SetObjectToLook(GameObject toLookAt) => objectToLook = toLookAt;
    public void SetObjectMarker(GameObject marker) => lookAtMarker = marker;
    public void SetCameraSpeed(float speed) => cameraSpeed = speed;
    public void SetWaitTime(float wait) => waitTime = wait;
    public void SetDelay(float delay) => delayTime = delay;
}