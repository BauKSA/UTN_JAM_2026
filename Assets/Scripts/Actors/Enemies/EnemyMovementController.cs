using UnityEngine;

[RequireComponent(typeof(PositionController))]
[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(MovementSettings))]
public class EnemyMovementController : MonoBehaviour
{
    private MovementStateController _movementStateController;
    private PositionController _positionController;
    private MovementSettings _movementSettings;

    void Awake()
    {
        _movementStateController = GetComponent<MovementStateController>();
        _positionController = GetComponent<PositionController>();
        _movementSettings = GetComponent<MovementSettings>();
    }

    void OnEnable()
    {
        _movementStateController.CanMove = true;
        _movementStateController.Movement.Down = true;
    }

    private void Update()
    {
        if (!_movementStateController.CanMove)
            return;

        Vector2 deltaMovement = Vector2.down * (_movementSettings.Speed.y * Time.deltaTime);
        _positionController.UpdatePosition(deltaMovement);
    }
}