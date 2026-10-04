using UnityEngine;
[RequireComponent(typeof(MovementStateController))]

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MovementSettings))]
public class CollectorPenguinCollision : MonoBehaviour
{
    private MovementStateController _movementState;
    private SpriteRenderer _spriteRenderer;
    private MovementSettings _movementSettings;
    private GameObject _iceCube = null;
    [SerializeField]
    private GameObject _iceCubePrefab;

    private bool _hasIceCube = false;
    private float _lastFlipTime = 1f;

    private void Awake()
    {
        _movementState = GetComponent<MovementStateController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _movementSettings = GetComponent<MovementSettings>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("CollectorPenguinLimit")) return;
        if (Time.time - _lastFlipTime < 0.2f) return;
        _lastFlipTime = Time.time;

        _movementState.Movement.Left = !_movementState.Movement.Left;
        _movementState.Movement.Right = !_movementState.Movement.Right;

        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _hasIceCube = !_hasIceCube;

        if (_hasIceCube)
        {
            _movementSettings.Speed = new(0.25f, _movementSettings.Speed.y);

            Vector2 iceCubePosition = new(transform.position.x - 0.45f, transform.position.y);

            _iceCube = Instantiate(_iceCubePrefab, iceCubePosition, Quaternion.identity);
            _iceCube.transform.SetParent(transform);
        }
        else
        {
            _movementSettings.Speed = new(0.5f, _movementSettings.Speed.y);
            Destroy(_iceCube);
        }
    }
}