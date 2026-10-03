using UnityEngine;

public class HealthStateController : MonoBehaviour
{
    [SerializeField] private bool _alive = true;

    public bool Alive { get => _alive; set => _alive = value; }
}