using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactLayer;

    private bool lastPrimaryHeld;
    private bool lastSecondaryHeld;

    private IPlayerInput input;
    private IInteractable currentTarget;
    

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        DetectTarget();

        if (currentTarget == null) return;

        HandlePrimary();
        HandleSecondary();
        HandleUse();
    }

    private void DetectTarget()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            currentTarget = hit.collider.GetComponent<IInteractable>();
        }
        else
        {
            currentTarget = GetComponent<GridInteractor>();
        }
    }
    private void HandlePrimary()
    {
        if (input.PrimaryPressed)
        {
            currentTarget?.Interact(InteractionType.Primary, InputPhase.Pressed);
            input.ConsumePrimary();
        }

        if (input.PrimaryHeld && !lastPrimaryHeld)
        {
            currentTarget?.Interact(InteractionType.Primary, InputPhase.Started);
        }

        if (input.PrimaryHeld)
        {
            currentTarget?.Interact(InteractionType.Primary, InputPhase.Held);
        }

        if (!input.PrimaryHeld && lastPrimaryHeld)
        {
            currentTarget?.Interact(InteractionType.Primary, InputPhase.Released);
        }

        lastPrimaryHeld = input.PrimaryHeld;
    }

    private void HandleSecondary()
    {
        if (input.SecondaryPressed)
        {
            currentTarget?.Interact(InteractionType.Secondary, InputPhase.Pressed);
            input.ConsumeSecondary();
        }

        if (input.SecondaryHeld && !lastSecondaryHeld)
        {
            currentTarget?.Interact(InteractionType.Secondary, InputPhase.Started);
        }

        if (input.SecondaryHeld)
        {
            currentTarget?.Interact(InteractionType.Secondary, InputPhase.Held);
        }

        if (!input.SecondaryHeld && lastSecondaryHeld)
        {
            currentTarget?.Interact(InteractionType.Secondary, InputPhase.Released);
        }
            
        lastSecondaryHeld = input.SecondaryHeld;
    }

    private void HandleUse()
    {
        if (input.UsePressed)
        {
            currentTarget.Interact(InteractionType.Use, InputPhase.Pressed);
            input.ConsumeUse();
        }
    }
}