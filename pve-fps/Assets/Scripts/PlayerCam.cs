using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    float xRotation;
    float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX; // Rotates player left and right
        xRotation -= mouseY; // Rotates player up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Restricts player to 90 degrees up and down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f); // Rotates player
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f); // Rotates camera
    }
}
