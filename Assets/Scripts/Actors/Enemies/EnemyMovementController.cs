using UnityEngine;

[RequireComponent(typeof(PositionController))]
[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(MovementSettings))]
public class EnemyMovementController : MonoBehaviour
{
    private MovementStateController _movementStateController;
    private PositionController _positionController;
    private MovementSettings _movementSettings;

    private GameObject _target;
    private float _rotationSpeed = 360f;

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
        _target = FindClosestPenguin();
    }

    private void Update()
    {
        if (!_movementStateController.CanMove)
            return;

        if (_target == null)
            _target = FindClosestPenguin();

        Vector2 direction = Vector2.down;

        if (_target != null)
        {
            direction = ((Vector2)_target.transform.position - (Vector2)transform.position).normalized;
            RotateTowards(direction);
        }

        Vector2 deltaMovement = direction * (_movementSettings.Speed.y * Time.deltaTime);
        _positionController.UpdatePosition(deltaMovement);
    }

    private void RotateTowards(Vector2 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -direction);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            _rotationSpeed * Time.deltaTime);
    }

    private GameObject FindClosestPenguin()
    {
        GameObject closest = null;
        float closestSqrDistance = float.MaxValue;
        Vector2 myPosition = transform.position;

        foreach (GameObject penguin in GameManager.Instance.Penguins)
        {
            if (penguin == null) continue;

            float sqrDistance = ((Vector2)penguin.transform.position - myPosition).sqrMagnitude;
            if (sqrDistance < closestSqrDistance)
            {
                closestSqrDistance = sqrDistance;
                closest = penguin;
            }
        }

        return closest;
    }
}