using UnityEngine;

/// <summary>
/// Controller for handling the interactions Based on different inputs and input type
/// </summary>

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Interactor interactor;

    private bool lastPrimaryHeld;
    private bool lastSecondaryHeld;

    private IPlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        HandlePrimary();
        HandleSecondary();
        HandleUse();
    }

    /// <summary>
    /// Input handling for Primary Button LClick, To detect hold and press
    /// </summary>

    private void HandlePrimary()
    {
        if (input.PrimaryPressed)
        {
            interactor.Interact(InteractionType.Primary, InputPhase.Pressed);
            input.ConsumePrimary();
        }

        if (input.PrimaryHeld && !lastPrimaryHeld)
        {
            interactor.Interact(InteractionType.Primary, InputPhase.Started);
        }

        if (input.PrimaryHeld)
        {
            interactor.Interact(InteractionType.Primary, InputPhase.Held);
        }

        if (!input.PrimaryHeld && lastPrimaryHeld)
        {
            interactor.Interact(InteractionType.Primary, InputPhase.Released);
        }

        lastPrimaryHeld = input.PrimaryHeld;
    }

    /// <summary>
    /// Handling input for secondary button RClick, Detecting hold and Press
    /// </summary>

    private void HandleSecondary()
    {
        if (input.SecondaryPressed)
        {
            interactor.Interact(InteractionType.Secondary, InputPhase.Pressed);
            input.ConsumeSecondary();
        }

        if (input.SecondaryHeld && !lastSecondaryHeld)
        {
            interactor.Interact(InteractionType.Secondary, InputPhase.Started);
        }

        if (input.SecondaryHeld)
        {
            interactor.Interact(InteractionType.Secondary, InputPhase.Held);
        }

        if (!input.SecondaryHeld && lastSecondaryHeld)
        {
            interactor.Interact(InteractionType.Secondary, InputPhase.Released);
        }
            
        lastSecondaryHeld = input.SecondaryHeld;
    }

    /// <summary>
    /// A third type of input for Consuming or Using Item (might need later on)
    /// </summary>
    private void HandleUse()
    {
        if (input.UsePressed)
        {
            interactor.Interact(InteractionType.Use, InputPhase.Pressed);
            input.ConsumeUse();
        }
    }
}