using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("Accion")]
    public bool idle = true;
    public bool moving;
    public bool attacking;
    public bool beingDamaged;
    public bool repairing;

    [Header("Objetivo")]
    public bool hasTarget;
    public bool targetInRange;

    [Header("Vida")]
    public bool lowHealth;
    public bool dead;
}
