using UnityEngine;

public class OsoIA : MonoBehaviour
{
    /*
    public Transform objetivo;
    public float velocidad = 2f;
    public float rangoAtaque = 1f;

    StateController state;

    void Awake()
    {
        state = GetComponent<StateController>();
    }

    void Update()
    {
        // Si el objetivo murió, lo olvidamos
        if (objetivo != null)
        {
            StateController stateObjetivo = objetivo.GetComponent<StateController>();
            if (stateObjetivo != null && stateObjetivo.dead)
            {
                objetivo = null;
            }
        }

        // Sin objetivo: quieto y sin hacer nada
        if (objetivo == null)
        {
            state.hasTarget = false;
            state.targetInRange = false;
            state.moving = false;
            state.attacking = false;
            state.idle = true;
            return;
        }

        state.hasTarget = true;

        float distancia = Vector2.Distance(transform.position, objetivo.position);
        state.targetInRange = distancia <= rangoAtaque;

        if (state.targetInRange)
        {
            state.moving = false;
            state.attacking = true;
            state.idle = false;
        }
        else
        {
            state.attacking = false;
            state.moving = true;
            state.idle = false;
            transform.position = Vector2.MoveTowards(
                transform.position, objetivo.position, velocidad * Time.deltaTime);
        }
    }
    */
}