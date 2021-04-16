using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [Header("LookAtMouseScript")]
    [SerializeField]
    LayerMask layerMask;
    Transform objectTransform;
    Camera mainCamera;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
        layerMask = LayerMask.GetMask("Ground");
    }

    public void RotateObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            Vector3 target = new Vector3(raycastHit.point.x, objectTransform.position.y, raycastHit.point.z);
            objectTransform.LookAt(target);
            Debug.DrawRay(objectTransform.position, target, Color.red);
        }
    }
    public void RotateObject(Transform secondBody, float desiredZRotation)
    {
        //float angleZ = secondBody.eulerAngles.z;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            Vector3 target = new Vector3(raycastHit.point.x, objectTransform.position.y, raycastHit.point.z);
            objectTransform.LookAt(target);
            target = new Vector3(raycastHit.point.x, secondBody.position.y, raycastHit.point.z);
            secondBody.LookAt(target);

            float distanceToTarget = Vector3.Distance(target, secondBody.position);
            Quaternion desiredRotation = Quaternion.Euler(new Vector3(secondBody.eulerAngles.x, secondBody.eulerAngles.y, desiredZRotation));
            secondBody.rotation = Quaternion.Lerp(desiredRotation, secondBody.rotation, distanceToTarget/8f);
        }
    }
}
