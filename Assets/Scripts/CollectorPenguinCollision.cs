using UnityEngine;

public class CollectorPenguinCollision : MonoBehaviour
{
    [SerializeField] private MovementStateController movementState;

    private void Awake()
    {
        if (movementState == null)
            movementState = GetComponent<MovementStateController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("CollectorPenguinLimit")) return;

        movementState.Movement.Left = !movementState.Movement.Left;
        movementState.Movement.Right = !movementState.Movement.Right;
    }
}