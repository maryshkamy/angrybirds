using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    public bool IsWithinSlingshotArea() {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        return Physics2D.OverlapPoint(worldPosition, _layerMask) ? true : false;
    }
}
