using Unity.VisualScripting;
using UnityEngine;

public class FPSCameraController : MonoBehaviour, ICameraController
{
    public Transform playerBody;

    [Header("Settings")]
    public float sensitivityX = 2f;
    public float sensitivityY = 0.5f;
    public float smoothTime = 0.05f;

    float xRotation = 0f;

    Vector2 currentLook;
    Vector2 currentLookVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Look(Vector2 input)
    {
        currentLook = Vector2.SmoothDamp(
            currentLook,
            input,
            ref currentLookVelocity,
            smoothTime
        );

        float mouseX = currentLook.x * sensitivityX * 10f * Time.deltaTime;
        float mouseY = currentLook.y * sensitivityY * 10f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}