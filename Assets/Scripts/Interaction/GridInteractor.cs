using UnityEngine;

/// <summary>
/// A basic interactor script to interact with the Grid System (Needs work and separation for interactor)
/// </summary>
public class GridInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private GridSystem gridSystem;

    /// <summary>
    /// Using the IInteractable interface for detecting interaction
    /// </summary>
    /// <param name="type"> Primary for LClick, Secondary for RClick </param>
    /// <param name="phase"> To define hold and press </param>

    public void Interact(InteractionType type, InputPhase phase)
    {
        if (phase != InputPhase.Pressed) return;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (!Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            return;
        }

        if (type == InteractionType.Primary)
        {
            gridSystem.TryPlaceBlock(hit.point + hit.normal * 0.5f);
        }

        if (type == InteractionType.Secondary)
        {
            gridSystem.TryRemoveBlock(hit.point - hit.normal * 0.5f);
        }
    }
}