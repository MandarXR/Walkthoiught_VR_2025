using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyAxisLockMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Camera-based directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignore vertical tilt
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * v + right * h) * moveSpeed;

        rb.velocity = new Vector3(
            moveDir.x,
            rb.velocity.y,
            moveDir.z
        );
    }
}
