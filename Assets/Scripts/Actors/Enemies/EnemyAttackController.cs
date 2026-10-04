using UnityEngine;

[RequireComponent(typeof(StateController))]
public class EnemyAttackController : MonoBehaviour
{
    private readonly float _attackTimeRate = 2f;
    private float _currentTime = 2f;

    private StateController _stateController;
    private GameObject _damageTarget = null;

    private void Awake()
    {
        _stateController = GetComponent<StateController>();
    }

    private void Update()
    {
        if (!_stateController.Attacking)
            return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _attackTimeRate)
        {
            _currentTime -= _attackTimeRate;
            GameManager.Instance.Damage();
        }
    }

    public void SetDamageTarget(GameObject target)
    {
        _damageTarget = target;
    }
}
