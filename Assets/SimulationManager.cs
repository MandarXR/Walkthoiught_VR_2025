using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance;

    public enum SimulationState
    {
        AutoMove,
        UserControl
    }

    public SimulationState currentState;

    public PlayerController playerController;
    public AutoMoveController autoMoveController;
    public TeleportController teleportController;
    public GameObject worldSpaceUI;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
     //   StartAutoMove();
    }

    public void StartExploreing()
    {
        StartAutoMove();
    }
    void StartAutoMove()
    {
        currentState = SimulationState.AutoMove;

        playerController.EnableControl(false);
        worldSpaceUI.SetActive(false);

        autoMoveController.StartMove();
    }

    public void OnReachedPointB()
    {
        currentState = SimulationState.UserControl;

        playerController.EnableControl(true);
        worldSpaceUI.SetActive(true);
    }
}
