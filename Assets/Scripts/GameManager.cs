using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> DamagedObjects;

    [SerializeField]
    private GameObject _Background;
    [SerializeField]
    private GameObject _DamageScreen;

    private readonly float _damageTimeRate = 0.25f;
    private float _currentTime = 0f;
    private bool _damageActive = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!_damageActive)
            return;

        _currentTime += Time.deltaTime;
        if(_currentTime >= _damageTimeRate)
        {
            _currentTime = 0;
            _damageActive = false;

            DamagedObjects.RemoveAll(damaged => damaged == null);
            foreach (GameObject damaged in DamagedObjects)
            {
                SpriteRenderer damagedSR = damaged.GetComponent<SpriteRenderer>();
                damagedSR.color = Color.white;
            }


            SpriteRenderer backgroundSR = _Background.GetComponent<SpriteRenderer>();
            backgroundSR.color = Color.white;

            SpriteRenderer damageScreenSR = _DamageScreen.GetComponent<SpriteRenderer>();
            damageScreenSR.enabled = false;
        }
    }

    public void Damage()
    {
        _damageActive = true;
        _currentTime = 0;

        DamagedObjects.RemoveAll(damaged => damaged == null);
        foreach (GameObject damaged in DamagedObjects)
        {
            SpriteRenderer damagedSR = damaged.GetComponent<SpriteRenderer>();
            damagedSR.color = Color.red;
        }

        SpriteRenderer backgroundSR = _Background.GetComponent<SpriteRenderer>();
        backgroundSR.color = Color.red;

        SpriteRenderer damageScreenSR = _DamageScreen.GetComponent<SpriteRenderer>();
        damageScreenSR.enabled = true;
    }
}
