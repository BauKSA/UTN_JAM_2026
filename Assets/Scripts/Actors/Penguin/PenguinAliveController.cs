using System;
using UnityEngine;

public class PenguinAliveController : MonoBehaviour
{
    public event Action Destroyed;
    private void OnDestroy()
    {
        Destroyed?.Invoke();
    }
}
