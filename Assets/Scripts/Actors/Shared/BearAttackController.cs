using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttackController : MonoBehaviour
{
    enum Estado { Moviendo, Atacando }
    Estado estado = Estado.Moviendo;

    public float velocidad = 1.5f;
    public float tiempoParaRomper = 1f;
    GameObject objetivoActual;

    void Update()
    {
        if (estado == Estado.Moviendo)
        {
            objetivoActual = BuscarBloqueMasAlto();

            if (objetivoActual == null)
            {
                transform.Translate(Vector2.down * velocidad * Time.deltaTime);
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, objetivoActual.transform.position, velocidad * Time.deltaTime);

            if (Vector2.Distance(transform.position, objetivoActual.transform.position) < 0.3f)
            {
                estado = Estado.Atacando;
                StartCoroutine(Atacar());
            }
        }
    }

    GameObject BuscarBloqueMasAlto()
    {
        GameObject[] bloques = GameObject.FindGameObjectsWithTag("igloo_block");

        if (bloques.Length == 0) bloques = GameObject.FindGameObjectsWithTag("igloo");

        GameObject masAlto = null;
        float yMax = -9999f;

        foreach (var b in bloques)
        {
            if (b.transform.parent != null && b.transform.parent.name.Contains("Muralla"))
            {
                if (b.transform.position.y > yMax)
                {
                    yMax = b.transform.position.y;
                    masAlto = b;
                }
            }
        }
        return masAlto;
    }

    IEnumerator Atacar()
    {
        Debug.Log("Oso atacando: " + objetivoActual.name);

        yield return new WaitForSeconds(tiempoParaRomper);

        if (objetivoActual != null)
        {
            Destroy(objetivoActual);
            var health = objetivoActual.GetComponentInParent<HealthIgluController>();
            if (health != null) health.TakeDamage(1);
        }

        estado = Estado.Moviendo;
        objetivoActual = null;
    }
}