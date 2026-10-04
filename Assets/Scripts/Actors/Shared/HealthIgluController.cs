using UnityEngine;

public class HealthIgluController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    private int currentHealth;

    void Awake() { currentHealth = maxHealth; }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida Muralla: " + currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
