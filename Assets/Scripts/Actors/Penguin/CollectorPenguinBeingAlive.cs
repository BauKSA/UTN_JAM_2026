using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (GameManager.Instance._win)
        {
            FollowBoat();
            return;
        }

        if (!_movementStateController.CanMove)
            return;

        Vector2 delta;

        if (_movementStateController.Movement.Right)
            delta = _movementSettings.Speed.x * Time.deltaTime * Vector2.right;
        else
            delta = _movementSettings.Speed.x * Time.deltaTime * Vector2.left;

        _positionController.UpdatePosition(delta);
    }

    private void FollowBoat()
    {
        GameObject boat = GameManager.Instance.Boat;

        if (boat == null)
            return;

        Vector2 direction = ((Vector2)boat.transform.position - (Vector2)transform.position).normalized;
        Vector2 delta = _movementSettings.Speed.x * Time.deltaTime * direction;

        _positionController.UpdatePosition(delta);
    }
}