using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    [Range(0.0f, 1f)]
    float cameraShaking;
    Camera mainCamera;
    Transform cameraTransform;
    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        cameraTransform = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = mainCamera.nearClipPlane;
        Vector3 desiredPosition = Vector3.Lerp(playerTransform.position, mainCamera.ScreenToWorldPoint(cursorPosition), cameraShaking);
        desiredPosition.y = 15f;
        cameraTransform.position = desiredPosition;
    }
}
