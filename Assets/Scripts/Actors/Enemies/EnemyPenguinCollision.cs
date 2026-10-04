using UnityEngine;

[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(StateController))]
[RequireComponent(typeof(EnemyAttackController))]
public class EnemyPenguinCollision : MonoBehaviour
{
    private MovementStateController _movementStateController;
    private StateController _stateController;
    private EnemyAttackController _attackController;

    private void Awake()
    {
        _movementStateController = GetComponent<MovementStateController>();
        _stateController = GetComponent<StateController>();
        _attackController = GetComponent<EnemyAttackController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        StateController penguinState = collider.gameObject.GetComponent<StateController>();
        penguinState.Attacking = false;

        MovementStateController penguinMovement = collider.gameObject.GetComponent<MovementStateController>();
        penguinMovement.CanMove = false;

        _attackController.AddDamageTarget(collider.gameObject);

        _movementStateController.CanMove = false;
        _stateController.Attacking = true;

        penguinState.BeingDamaged = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Penguin"))
            return;

        _attackController.RemoveDamageTarget(collider.gameObject);

        if (!_attackController.HasTargets)
        {
            _movementStateController.CanMove = true;
            _stateController.Attacking = false;
        }

        if (collider.gameObject == null) return;

        MovementStateController penguinMovement = collider.gameObject.GetComponent<MovementStateController>();
        if(penguinMovement)
            penguinMovement.CanMove = true;

        StateController penguinState = collider.gameObject.GetComponent<StateController>();
        if (penguinState)
        {
            penguinState.Attacking = true;
            penguinState.BeingDamaged = false;
        }
    }
}