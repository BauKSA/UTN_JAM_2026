using UnityEngine;

public class IglooBlock : MonoBehaviour
{
    public void ReceiveHit(int damage)
    {
        HealthIgluController wallHealth = GetComponentInParent<HealthIgluController>();

        if (wallHealth != null)
        {
            wallHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
