using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> Enemies;
    public List<GameObject> Penguins;

    [SerializeField]
    public GameObject Boat;
    [SerializeField]
    private GameObject _Collector;
    [SerializeField]
    private GameObject _Background;
    [SerializeField]
    private GameObject _DamageScreen;

    public bool _win = false;
    public int _boatCubes = 0;
    private readonly int _boatCubesLimit = 10;

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
    }

    private void Start()
    {
        Penguins.Add(_Collector);
    }

    private void Update()
    {
        if (!_damageActive)
            return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _damageTimeRate)
        {
            _currentTime = 0;
            _damageActive = false;

            SpriteRenderer backgroundSR = _Background.GetComponent<SpriteRenderer>();
            backgroundSR.color = Color.white;

            SpriteRenderer damageScreenSR = _DamageScreen.GetComponent<SpriteRenderer>();
            damageScreenSR.enabled = false;
        }

        if(_Collector == null && !_win)
        {
            Debug.Log("game over");
            SceneManager.LoadScene("gameover");
        }

        if (_boatCubes == _boatCubesLimit)
        {
            _win = true;
        }
    }

    public void Damage()
    {
        _damageActive = true;
        _currentTime = 0;

        SpriteRenderer backgroundSR = _Background.GetComponent<SpriteRenderer>();
        backgroundSR.color = Color.red;

        SpriteRenderer damageScreenSR = _DamageScreen.GetComponent<SpriteRenderer>();
        damageScreenSR.enabled = true;
    }
}
