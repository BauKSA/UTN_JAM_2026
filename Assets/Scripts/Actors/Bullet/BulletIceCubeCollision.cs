using UnityEngine;

public class BulletIceCubeCollision : MonoBehaviour
{
    private bool _hit = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_hit)
            return;

        if (!collider.gameObject.CompareTag("IceCube"))
            return;

        if (collider.gameObject.transform.position.y < 0f)
            return;

        _hit = true;

        collider.gameObject.GetComponent<StateController>().BeingDamaged = true;
        collider.gameObject.GetComponent<HealthController>().GetDamage();

        Destroy(gameObject);
    }
}
