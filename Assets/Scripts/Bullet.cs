using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velocidad = 5f;
    public float tiempoDeVida = 3f;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }


}
