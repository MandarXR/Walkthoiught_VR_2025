using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public RigidbodyAxisLockMovement movement;
    public CameraLook look;

    public void EnableControl(bool enable)
    {
        movement.enabled = enable;
        look.enabled = enable;
    }
}
