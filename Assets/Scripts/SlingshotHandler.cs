using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotHandler : MonoBehaviour
{
    [Header("Line Renderer References")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [Header("Transform References")]
    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [Header("Collider References")]
    [SerializeField] private SlingshotArea _slingshotArea;

    [Header("Stats")]
    [SerializeField] private float _maxDistance = 3.5f;

    private Vector2 _slingshotLinesPosition;
    private bool _clickedWithinArea;

    private void Awake()
    {
        SetLines(_centerPosition.position);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _slingshotArea.IsWithinSlingshotArea())
        {
            _clickedWithinArea = true;
        }

        if (Mouse.current.leftButton.isPressed && _clickedWithinArea)
        {
            DrawSlingshot();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            _clickedWithinArea = false;
            SetLines(_centerPosition.position);
        }
    }

    private void DrawSlingshot()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (touchPosition.x < _centerPosition.position.x)
        {
            _slingshotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchPosition - _centerPosition.position, _maxDistance);
            SetLines(_slingshotLinesPosition);
        }
    }

    private void SetLines(Vector2 position)
    {
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
    }
}
