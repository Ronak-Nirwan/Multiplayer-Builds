using UnityEngine;

/// <summary>
/// The final script for controlling the player, Hooks both Movement and camera
/// </summary>

public class PlayerController : MonoBehaviour
{
    private IPlayerInput input;
    private IMovement movement;
    private ICameraController cameraController;

    [SerializeField] private CharacterController controller;
    [SerializeField] private FPSCameraController cameraScript;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();

        movement = new CharacterMovement(
            controller,
            5f,
            1.5f
        );

        cameraController = cameraScript;
    }

    private void Update()
    {
        movement.Move(input.Move, input.SprintHeld);

        if (input.JumpPressed)
        {
            movement.Jump();
            input.ConsumeJump();
        }

        cameraController.Look(input.Look);

        // Small respawn logic for now

        if(transform.position.y < -10f)
        {
            transform.position = new Vector3(50, 10, 50);
        }
    }

}