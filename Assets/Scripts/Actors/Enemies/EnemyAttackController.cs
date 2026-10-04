using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class EnemyAttackController : MonoBehaviour
{
    private readonly float _attackTimeRate = 2f;
    private float _currentTime = 2f;

    private StateController _stateController;
    private readonly List<GameObject> _damageTargets = new List<GameObject>();

    public bool HasTargets => _damageTargets.Count > 0;

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

            for (int i = _damageTargets.Count - 1; i >= 0; i--)
            {
                GameObject target = _damageTargets[i];

                if (!target)
                {
                    _damageTargets.RemoveAt(i);
                    continue;
                }

                target.GetComponent<HealthController>().GetDamage();
            }
        }
    }

    public void AddDamageTarget(GameObject target)
    {
        if (!_damageTargets.Contains(target))
            _damageTargets.Add(target);
    }

    public void RemoveDamageTarget(GameObject target)
    {
        _damageTargets.Remove(target);
    }
}