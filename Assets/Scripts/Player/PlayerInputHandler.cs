using UnityEngine;

/// <summary>
/// The overall input handler for Managing the New input system
/// </summary>
public class PlayerInputHandler : MonoBehaviour, IPlayerInput
{
    private InputSystem_Actions controls;

    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool SprintHeld { get; private set; }

    public bool PrimaryPressed { get; private set; }
    public bool PrimaryHeld { get; private set; }

    public bool SecondaryPressed { get; private set; }
    public bool SecondaryHeld { get; private set; }

    public bool UsePressed { get; private set; }

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => Move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => Move = Vector2.zero;

        controls.Player.Look.performed += ctx => Look = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => Look = Vector2.zero;

        controls.Player.Jump.performed += ctx => JumpPressed = true;


        controls.Player.Sprint.performed += ctx => SprintHeld = true;
        controls.Player.Sprint.canceled += ctx => SprintHeld = false;

        controls.Player.Primary.started += ctx =>
        {
            PrimaryPressed = true;
            PrimaryHeld = true;
        };

        controls.Player.Primary.canceled += ctx =>
        {
            PrimaryHeld = false;
        };

        controls.Player.Secondary.started += ctx =>
        {
            SecondaryPressed = true;
            SecondaryHeld = true;
        };

        controls.Player.Secondary.canceled += ctx =>
        {
            SecondaryHeld = false;
        };

        controls.Player.Use.performed += ctx => UsePressed = true;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void ConsumeJump()
    {
        JumpPressed = false;
    }

    public void ConsumePrimary() => PrimaryPressed = false;
    public void ConsumeSecondary() => SecondaryPressed = false;
    public void ConsumeUse() => UsePressed = false;
}