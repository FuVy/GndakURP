using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Character character;
    Transform characterTransform;
    [SerializeField]
    [Range(0.0f, 1f)]
    float followDistance;
    Camera mainCamera;
    Transform cameraTransform;
    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        cameraTransform = GetComponent<Transform>();
        characterTransform = character.transform;
    }
    void FixedUpdate()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = mainCamera.nearClipPlane;
        Vector3 desiredPosition = Vector3.Lerp(characterTransform.position, mainCamera.ScreenToWorldPoint(cursorPosition), followDistance);
        desiredPosition.y = 15f;
        cameraTransform.position = desiredPosition;
    }
    public void CheckPlayer(Character character)
    {
        if (this.character == character)
        {
            this.enabled = false;
        }
    }
}
