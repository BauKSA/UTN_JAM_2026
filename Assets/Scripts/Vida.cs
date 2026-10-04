using UnityEngine;

public class Vida : MonoBehaviour
{
    /*
    public float vidaMaxima = 100f;
    public float vidaActual;

    StateController state;

    void Awake()
    {
        state = GetComponent<StateController>();
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        if (state.dead) return;

        vidaActual -= cantidad;

        state.beingDamaged = true;
        CancelInvoke(nameof(FinDanio));
        Invoke(nameof(FinDanio), 0.2f);

        state.lowHealth = vidaActual <= vidaMaxima * 0.3f;

        if (vidaActual <= 0f)
        {
            vidaActual = 0f;
            state.dead = true;
        }
    }

    void FinDanio()
    {
        state.beingDamaged = false;
    }
    */
}