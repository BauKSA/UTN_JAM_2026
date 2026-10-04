using UnityEngine;
[RequireComponent(typeof(PositionController))]

[RequireComponent(typeof(MovementSettings))]
[RequireComponent(typeof(MovementStateController))]
public class CollectorPenguinBeingAlive : MonoBehaviour
{
    private PositionController _positionController;
    private MovementSettings _movementSettings;
    private MovementStateController _movementStateController;

    private void Awake()
    {
        _positionController = GetComponent<PositionController>();
        _movementSettings = GetComponent<MovementSettings>();
        _movementStateController = GetComponent<MovementStateController>();
    }

    private void Update()
    {
        if (!_movementStateController.CanMove)
            return;

        Vector2 delta;

        if (_movementStateController.Movement.Right)
            delta = _movementSettings.Speed.x * Time.deltaTime * Vector2.right;
        else
            delta = _movementSettings.Speed.x * Time.deltaTime * Vector2.left;

        _positionController.UpdatePosition(delta);
    }
}
