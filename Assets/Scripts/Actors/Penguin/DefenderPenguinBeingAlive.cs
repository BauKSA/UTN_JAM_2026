using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(StateController))]
public class DefenderPenguinBeingAlive : MonoBehaviour
{
    private StateController _stateController;

    private readonly float _cadence = 1f;
    private float _timeSinceLastShot = 0f;

    [SerializeField]
    private GameObject _bullet;

    private void Awake()
    {
        _stateController = GetComponent<StateController>();
    }

    void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
        if (_timeSinceLastShot >= _cadence)
        {
            Shoot();
            _timeSinceLastShot -= _cadence;
        }
    }

    private void Shoot()
    {
        if (!_bullet) return;
        if (!_stateController.Attacking)
            return;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float offset = spriteRenderer.bounds.size.y / 2 + _bullet.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Vector2 position = new (transform.position.x, transform.position.y + offset);
        Instantiate(_bullet, position, _bullet.transform.rotation);
    }
}
