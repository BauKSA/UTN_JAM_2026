using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(StateController))]

[RequireComponent(typeof(EnemyAttackController))]
public class EnemyPenguinCollision : MonoBehaviour
{
    private MovementStateController _movementStateController;
    private StateController _stateController;

    private void Awake()
    {
        _movementStateController = GetComponent<MovementStateController>();
        _stateController = GetComponent<StateController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        collider.gameObject.GetComponent<StateController>().Attacking = false;
        collider.gameObject.GetComponent<StateController>().BeingDamaged = true;

        _movementStateController.CanMove = false;
        _stateController.Attacking = true;

        GameManager.Instance.DamagedObjects.Add(collider.gameObject);

        GetComponent<EnemyAttackController>().SetDamageTarget(collider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        _movementStateController.CanMove = true;
    }
}
