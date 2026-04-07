using UnityEngine;

/// <summary>
/// A first person Camera controller
/// </summary>
public class FPSCameraController : MonoBehaviour, ICameraController
{
    public Transform PlayerBody; // Reference to the player body

    [Header("Settings")]
    public float SensitivityX = 2f;
    public float SensitivityY = 0.5f;
    public float SmoothTime = 0.05f;

    float xRotation = 0f;

    Vector2 currentLook;
    Vector2 currentLookVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Calculating the camera movement for the given mouse input
    /// </summary>
    /// <param name="input"></param>

    public void Look(Vector2 input)
    {
        currentLook = Vector2.SmoothDamp(
            currentLook,
            input,
            ref currentLookVelocity,
            SmoothTime
        );

        float mouseX = currentLook.x * SensitivityX * 10f * Time.deltaTime;
        float mouseY = currentLook.y * SensitivityY * 10f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}