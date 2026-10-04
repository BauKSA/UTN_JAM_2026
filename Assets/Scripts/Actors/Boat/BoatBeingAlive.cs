using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(MovementSettings))]

[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(PositionController))]
public class BoatBeingAlive : MonoBehaviour
{
    private MovementStateController _movementState;
    private MovementSettings _movementSettings;
    private PositionController _positionController;

    private readonly float _cooldownToWin = 2f;
    private float _currentTime = 0f;

    private void Awake()
    {
        _movementSettings = GetComponent<MovementSettings>();
        _movementState = GetComponent<MovementStateController>();
        _positionController = GetComponent<PositionController>();
    }

    void Update()
    {
        if (_movementState.Movement.Left)
        {
            _positionController.MoveBackward(_movementSettings.Speed.x, _movementSettings.Acceleration);

            _currentTime += Time.deltaTime;
            if(_currentTime >= _cooldownToWin)
            {
                Debug.Log("time passed");
                SceneManager.LoadScene("youwin");
            }

            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        Destroy(collider.gameObject);

        _movementState.Movement.Left = true;
    }
}
