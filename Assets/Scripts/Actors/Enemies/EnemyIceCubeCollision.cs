using UnityEngine;

[RequireComponent(typeof(MovementStateController))]
[RequireComponent(typeof(StateController))]
[RequireComponent(typeof(EnemyAttackController))]
public class EnemyIceCubeCollision : MonoBehaviour
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
        if (!collider.gameObject.CompareTag("IceCube"))
            return;

        collider.gameObject.GetComponent<StateController>().BeingDamaged = true;

        _attackController.AddDamageTarget(collider.gameObject);

        _movementStateController.CanMove = false;
        _stateController.Attacking = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("IceCube"))
            return;

        _attackController.RemoveDamageTarget(collider.gameObject);

        // Solo se libera al oso si ya no queda ningún cubo en contacto
        if (!_attackController.HasTargets)
        {
            _movementStateController.CanMove = true;
            _stateController.Attacking = false;
        }
    }
}