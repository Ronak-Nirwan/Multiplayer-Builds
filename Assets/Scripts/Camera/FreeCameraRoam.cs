using UnityEngine;

/// <summary>
/// Generic free roam script for camera, to move freely in game scene
/// </summary>
public class FreeCameraRoam : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float cameraSensitivity = 200f;
    private GridSystem gridSystem;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gridSystem = FindFirstObjectByType<GridSystem>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float q = Input.GetAxisRaw("QE");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Translate(
            h * moveSpeed * Time.deltaTime,
            q * moveSpeed * Time.deltaTime,
            v * moveSpeed * Time.deltaTime
        );

        transform.Rotate(Vector3.up * mouseX * cameraSensitivity * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * -mouseY * cameraSensitivity * Time.deltaTime, Space.Self);


        // Basic Interaction for testing


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
            {
                gridSystem.TryPlaceBlock(hit.point + hit.normal * 0.5f);
                Debug.DrawRay(hit.point, hit.normal, Color.red, 2f);
            }

        }

        else if (Input.GetMouseButtonUp(1)) 
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);

            gridSystem.TryRemoveBlock(hit.point - hit.normal * 0.5f);
        }
    }
}
