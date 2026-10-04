using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PenguinAliveController : MonoBehaviour
{
    public event Action Destroyed;
    private bool _beingDestroyed = false;
    private readonly float _destroyDelay = 10f;
    private float _currentTime = 0f;
    private readonly float _blinkDelay = 0.2f;
    private float _currentBlink = 0f;
    private bool _blink = false;

    void Update()
    {
        _currentTime += Time.deltaTime;
        if (!_beingDestroyed && _currentTime >= _destroyDelay - 2)
        {
            _beingDestroyed = true;
        }

        if (_currentTime >= _destroyDelay)
        {
            Destroy(gameObject);
        }

        if (_beingDestroyed)
        {
            _currentBlink += Time.deltaTime;
            if(_currentBlink >= _blinkDelay)
            {
                _currentBlink = 0f;
                Color color;
                if (_blink) color = Color.white;
                else color = Color.red;

                _blink = !_blink;

                GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke();
    }
}
