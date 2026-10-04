using UnityEngine;

[RequireComponent(typeof(PositionController))]
[RequireComponent(typeof(MovementSettings))]
public class BulletBeingAlive : MonoBehaviour
{
    private PositionController _positionController;
    private MovementSettings _movementSettings;

    private readonly float _destroyTime = 1f;
    private float _currentTime = 0f;

    private void Awake()
    {
        _positionController = GetComponent<PositionController>();
        _movementSettings = GetComponent<MovementSettings>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _destroyTime)
            Destroy(gameObject);

        _positionController.MoveBackward(_movementSettings.Speed.x, _movementSettings.Acceleration);
    }
}
