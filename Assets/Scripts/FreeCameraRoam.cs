using UnityEngine;

public class FreeCameraRoam : MonoBehaviour
{
    float speed = 10f;
    float sensitivity = 200f;
    GridSystem gridSystem;

    void Start()
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
            h * speed * Time.deltaTime,
            q * speed * Time.deltaTime,
            v * speed * Time.deltaTime
        );

        transform.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * -mouseY * sensitivity * Time.deltaTime, Space.Self);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
            {
                gridSystem.PlaceBlockAt(hit.point + hit.normal * 0.5f);
                Debug.DrawRay(hit.point, hit.normal, Color.red, 2f);
            }

            //Debug.Log(hit.point);

        }

        else if (Input.GetMouseButtonUp(1)) 
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);

            if(hit.collider.CompareTag("Box"))
            {
                Destroy(hit.collider.gameObject);
            }
            
        }
    }
}
