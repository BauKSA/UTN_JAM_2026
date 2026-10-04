using Unity.VisualScripting;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    private Camera mainCamera_;
    private int penguinCount_ = 0;
    private readonly int maxPenguinCount_ = 5;

    private readonly float _spawnCooldown = 2f;
    private bool _canSpawn = true;
    private float _currentTime = 0f;

    [SerializeField]
    private GameObject defenderPenguin_;
    [SerializeField]
    private GameObject spawnZone_;

    private void Awake()
    {
        mainCamera_ = Camera.main;
    }

    void Update()
    {
        if (!_canSpawn)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime >= _spawnCooldown)
            {
                _currentTime = 0;
                _canSpawn = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (penguinCount_ >= maxPenguinCount_)
            {
                return;
            }

            if (!_canSpawn) return;
            _canSpawn = false;
            
            Vector2 clickPosition = Input.mousePosition;
            Vector2 position = mainCamera_.ScreenToWorldPoint(clickPosition);

            if (!IsOnSpawnZone(position))
            {
                return;
            }

            GameObject penguin = Instantiate(defenderPenguin_, position, Quaternion.identity);
            penguin.GetComponent<PenguinAliveController>().Destroyed += OnPenguinDestroyed;
            penguinCount_++;
        }
    }

    private void OnPenguinDestroyed()
    {
        penguinCount_--;
    }

    private bool IsOnSpawnZone(Vector2 position)
    {
        BoxCollider2D spawnZoneCollider = spawnZone_.GetComponent<BoxCollider2D>();

        return spawnZoneCollider.OverlapPoint(position);
    }
}
