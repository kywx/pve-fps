using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSens = 30f;
    public float ySens = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // calculate camera rotation for looking up and down
        xRotation -= mouseY * Time.deltaTime * ySens;
        xRotation = Mathf.Clamp(xRotation, -90f, 50f);
        
        // apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rotate player to look left and right
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSens);
    }
}
