using UnityEngine;
using System.Collections;

public class AutoMoveController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    private Transform player;

    void Awake()
    {
        player = transform;
    }

    public void StartMove()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (Vector3.Distance(player.position, pointB.position) > 0.05f)
        {
            player.position = Vector3.MoveTowards(
                player.position,
                pointB.position,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        SimulationManager.Instance.OnReachedPointB();
    }
}
