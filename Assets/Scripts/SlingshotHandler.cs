using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotHandler : MonoBehaviour
{
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [SerializeField] private float _maxDistance = 3.5f;

    private Vector2 _slingshotLinesPosition;

    private void Start()
    {
        SetLines(_idlePosition.position);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            DrawSlingshot();
        }
    }

    private void DrawSlingshot()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _slingshotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchPosition - _centerPosition.position, _maxDistance);
        SetLines(_slingshotLinesPosition);
    }

    private void SetLines(Vector2 position)
    {
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
    }
}
