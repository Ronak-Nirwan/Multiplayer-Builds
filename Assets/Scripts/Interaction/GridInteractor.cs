using UnityEngine;

public class GridInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private GridSystem gridSystem;

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