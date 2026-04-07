using UnityEngine;

/// <summary>
/// Input interfacing for all types of character input
/// </summary>
public interface IPlayerInput
{
    Vector2 Move { get; }
    Vector2 Look { get; }
    bool JumpPressed { get; }
    void ConsumeJump();
    bool SprintHeld { get; }

    bool PrimaryPressed { get; }
    bool PrimaryHeld { get; }

    bool SecondaryPressed { get; }
    bool SecondaryHeld { get; }

    bool UsePressed { get; }

    void ConsumePrimary();
    void ConsumeSecondary();
    void ConsumeUse();
}