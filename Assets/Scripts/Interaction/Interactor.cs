using UnityEngine;

/// <summary>
/// A universal interactor script for using interaction on different types of objects
/// </summary>

public class Interactor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 5f;
    [SerializeField] private LayerMask interactLayer;

    [Header("Systems")]
    [SerializeField] private GridSystem gridSystem;

    public void Interact(InteractionType type, InputPhase phase)
    {
        HandleGrid(type, phase); // only handles grid based interaction for now, will be expaneded when more items are there
    }

    private void HandleGrid(InteractionType type, InputPhase phase)
    {
        if (!TryGetRaycast(out RaycastHit hit))
            return;

        if (phase != InputPhase.Pressed) return;

        Vector3Int gridPos = gridSystem.WorldToGrid(hit.point + hit.normal * 0.5f);

        if (type == InteractionType.Primary)
        {
            if (!gridSystem.HasBlockAt(gridPos))
            {
                gridSystem.TryPlaceBlock(gridSystem.GridToWorld(gridPos));
            }
        }

        if (type == InteractionType.Secondary)
        {
            gridSystem.TryRemoveBlock(hit.point - hit.normal * 0.5f);
        }
    }

    private bool TryGetRaycast(out RaycastHit hit)
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        return Physics.Raycast(ray, out hit, interactDistance, interactLayer);
    }
}