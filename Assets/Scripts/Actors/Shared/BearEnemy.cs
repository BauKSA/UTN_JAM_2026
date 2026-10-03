using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PositionController))]
[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(BoxCollider2D))]
public class BearEnemy : MonoBehaviour
{
    [SerializeField] private MovementStateController _movementStateController;

    void Awake()
    {
        _movementStateController = GetComponent<MovementStateController>();
    }

    void OnEnable()
    {
        // TAREA 2: Movimiento hacia abajo
        _movementStateController.Active = true;
        _movementStateController.CanMove = true;
        _movementStateController.Movement.Down = true;
        _movementStateController.Movement.Up = false;
        _movementStateController.Movement.Left = false;
        _movementStateController.Movement.Right = false;
    }

    void OnDisable()
    {
        // Frenar cuando se desactiva
        _movementStateController.Movement.Down = false;
    }
}