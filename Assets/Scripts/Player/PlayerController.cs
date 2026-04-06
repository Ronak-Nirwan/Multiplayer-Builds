using UnityEngine;

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
    }
}