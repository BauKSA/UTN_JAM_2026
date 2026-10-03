using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PositionController : MonoBehaviour
{
    private float _currentSpeed;
    private Vector2 _pendingMove;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_pendingMove != Vector2.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + _pendingMove);
            _pendingMove = Vector2.zero;
        }
    }

    public void SnapTo(Vector2 position)
    {
        _pendingMove = Vector2.zero;
        _currentSpeed = 0f;

        _rigidbody.position = position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void UpdatePosition(Vector2 delta)
    {
        _pendingMove += delta;
    }

    public void MoveForward(float speed, float acceleration)
    {
        _currentSpeed += acceleration * Time.deltaTime;
        _currentSpeed = Mathf.Clamp(_currentSpeed, -speed, speed);

        Vector2 forward = (Vector2)transform.right * (_currentSpeed * Time.deltaTime);
        UpdatePosition(forward);
    }

    public void MoveBackward(float speed, float acceleration, bool limited = false)
    {
        if (limited && _currentSpeed == 0)
            return;

        _currentSpeed -= acceleration * Time.deltaTime;
        _currentSpeed = Mathf.Clamp(_currentSpeed, -speed, speed);

        if (limited && _currentSpeed < 0)
        {
            _currentSpeed = 0;
        }

        Vector2 backward = (Vector2)transform.right * (_currentSpeed * Time.deltaTime);
        UpdatePosition(backward);
    }


    public void Decelerate(float deceleration)
    {
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, 0f, deceleration * Time.deltaTime);

        Vector2 movement = (Vector2)transform.right * (_currentSpeed * Time.deltaTime);
        UpdatePosition(movement);
    }
}