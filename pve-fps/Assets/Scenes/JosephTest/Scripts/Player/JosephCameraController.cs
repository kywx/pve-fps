using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float sensX;
    public float sensY;
    public Transform orientation;


    float _xRotation;
    float _yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        _yRotation += mouseX;
        _xRotation -= mouseY;

        // restricts camera movement to 90 degrees up and down
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        //rotate camera and orientation
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, _yRotation, 0);

    }
}
