using UnityEngine;
[RequireComponent(typeof(MovementStateController))]

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MovementSettings))]
public class CollectorPenguinCollision : MonoBehaviour
{
    private MovementStateController _movementState;
    private SpriteRenderer _spriteRenderer;
    private MovementSettings _movementSettings;

    private bool _hasIceCube = false;

    private void Awake()
    {
        _movementState = GetComponent<MovementStateController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _movementSettings = GetComponent<MovementSettings>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("CollectorPenguinLimit")) return;

        _movementState.Movement.Left = !_movementState.Movement.Left;
        _movementState.Movement.Right = !_movementState.Movement.Right;

        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _hasIceCube = !_hasIceCube;

        if (_hasIceCube)
            _movementSettings.Speed = new(0.25f, _movementSettings.Speed.y);
        else
            _movementSettings.Speed = new(0.5f, _movementSettings.Speed.y);
    }
}