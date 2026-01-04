using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour
{
    public Transform[] teleportPoints;
    public float teleportSpeed = 5f;

    public void TeleportToIndex(int index)
    {
        if (index < 0 || index >= teleportPoints.Length)
            return;

        StartCoroutine(TeleportToPosition(teleportPoints[index]));
    }

    IEnumerator SmoothTeleport(Transform target)
    {
        Transform player = SimulationManager.Instance.playerController.transform;

        while (Vector3.Distance(player.position, target.position) > 0.05f)
        {
            player.position = Vector3.Lerp(
                player.position,
                target.position,
                teleportSpeed * Time.deltaTime
            );

            yield return null;
        }
    }

    IEnumerator TeleportToPosition(Transform target)
    {
        Transform player = SimulationManager.Instance.playerController.transform;
        player.position = target.position;

        yield return null;
    }

}
