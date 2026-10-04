using UnityEngine;
[RequireComponent(typeof(StateController))]

[RequireComponent(typeof(SpriteRenderer))]
public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _health = 3f;

    [SerializeField]
    private float _damageRate = 1f;

    private readonly float _damageTimeRate = 0.25f;
    private float _currentTime = 0f;

    private StateController _stateController;

    void Awake()
    {
        _stateController = GetComponent<StateController>();
    }

    public void GetDamage()
    {
        _stateController.BeingDamaged = true;
        _health -= _damageRate;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        if (_health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!_stateController.BeingDamaged)
            return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _damageTimeRate)
        {
            _currentTime = 0f;
            _stateController.BeingDamaged = false;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }
}