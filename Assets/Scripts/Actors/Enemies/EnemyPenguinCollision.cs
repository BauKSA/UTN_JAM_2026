using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MovementStateController))]
public class EnemyPenguinCollision : MonoBehaviour
{
    private MovementStateController _movementStateController;

    private void Awake()
    {
        _movementStateController = GetComponent<MovementStateController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
        {
            Debug.Log("Enemy collision with unknown");
            return;
        }

        Debug.Log("Enemy collision with Penguin");
        _movementStateController.CanMove = false;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        _movementStateController.CanMove = true;
    }
}
