using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class EnemyBulletCollision : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Bullet"))
            return;

        Destroy(collider.gameObject);
        _healthController.GetDamage();
    }
}
