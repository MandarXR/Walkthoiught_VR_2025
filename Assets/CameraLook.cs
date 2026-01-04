using UnityEngine;

public class CameraLook : MonoBehaviour
{
  public float mouseSensitivity = 200f;
    public float minY = -90f;
    public float maxY = 90f;

    private float xRotation;

    void Update()
    {
        if (!Input.GetMouseButton(1))
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate player horizontally
        transform.parent.Rotate(Vector3.up * mouseX);

        // Vertical look
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
