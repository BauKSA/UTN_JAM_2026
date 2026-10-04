using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(StateController))]
public class DefenderPenguinBeingAlive : MonoBehaviour
{
    private StateController _stateController;
    private SpriteRenderer _spriteRenderer;

    private readonly float _cadence = 1f;
    private float _timeSinceLastShot = 0f;

    private GameObject _target;

    [SerializeField]
    private GameObject _bullet;

    private void Awake()
    {
        _stateController = GetComponent<StateController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_target)
            _target = FindClosestEnemy();

        if (_target)
            RotateTowards(_target.transform.position);

        _timeSinceLastShot += Time.deltaTime;
        if (_timeSinceLastShot >= _cadence)
        {
            Shoot();
            _timeSinceLastShot -= _cadence;
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float minSqrDistance = float.MaxValue;

        foreach (GameObject enemy in GameManager.Instance.Enemies)
        {
            if (!enemy)
                continue;

            float sqrDistance = ((Vector2)enemy.transform.position - (Vector2)transform.position).sqrMagnitude;
            if (sqrDistance < minSqrDistance)
            {
                minSqrDistance = sqrDistance;
                closest = enemy;
            }
        }

        return closest;
    }

    private void RotateTowards(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;
        if (direction.sqrMagnitude < 0.0001f)
            return;

        transform.up = direction;
    }

    private void Shoot()
    {
        if (!_bullet) return;
        if (!_stateController.Attacking) return;

        float penguinHalfHeight = _spriteRenderer.sprite.bounds.size.y * transform.lossyScale.y / 2f;

        SpriteRenderer bulletRenderer = _bullet.GetComponent<SpriteRenderer>();
        float bulletHalfLength = bulletRenderer.sprite.bounds.size.x * _bullet.transform.lossyScale.x / 2f;

        float offset = penguinHalfHeight + bulletHalfLength;

        Vector2 position = (Vector2)transform.position + (Vector2)transform.up * offset;
        Instantiate(_bullet, position, transform.rotation * _bullet.transform.rotation);
    }
}