using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _bear;
    [SerializeField]
    private GameObject _seal;
    [SerializeField]
    private GameObject _wolf;

    private readonly float _firstSpawnDelay = 2.5f;
    private readonly float _startInterval = 8.5f;
    private readonly float _minInterval = 2.2f;
    private readonly float _rampDuration = 220f;
    private readonly float _jitter = 0.2f;

    private readonly float _chanceSingle = 0.65f;
    private readonly float _chanceDouble = 0.28f;

    private readonly int _spawnsPerWave = 8;
    private readonly int _waveExtraEnemies = 3;
    private readonly float _waveSpacing = 0.5f;

    private readonly float _minX = -3.5f;
    private readonly float _maxX = 3.5f;
    private readonly float _minSeparation = 1.2f;

    private int _spawnCount;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(_firstSpawnDelay);

        while (true)
        {
            SpawnGroup(GetGroupSize());
            _spawnCount++;

            if (_spawnsPerWave > 0 && _spawnCount % _spawnsPerWave == 0)
            {
                for (int i = 0; i < _waveExtraEnemies; i++)
                {
                    yield return new WaitForSeconds(_waveSpacing);
                    SpawnGroup(Random.value < 0.5f ? 2 : 1);
                }
            }

            yield return new WaitForSeconds(GetNextInterval());
        }
    }

    private int GetGroupSize()
    {
        float r = Random.value;
        if (r < _chanceSingle) return 1;
        if (r < _chanceSingle + _chanceDouble) return 2;
        return 3;
    }

    private float GetNextInterval()
    {
        float progress = Mathf.Clamp01(Time.timeSinceLevelLoad / _rampDuration);
        float t = Mathf.SmoothStep(0f, 1f, progress);

        float interval = Mathf.Lerp(_startInterval, _minInterval, t);
        interval *= 1f + Random.Range(-_jitter, _jitter);

        return Mathf.Max(_minInterval * 0.8f, interval);
    }

    private void SpawnGroup(int count)
    {
        var usedX = new List<float>();

        for (int i = 0; i < count; i++)
        {
            float x = PickX(usedX);
            usedX.Add(x);
            SpawnEnemy(x);
        }
    }

    private float PickX(List<float> usedX)
    {
        float x = Random.Range(_minX, _maxX);

        for (int attempt = 0; attempt < 10; attempt++)
        {
            bool tooClose = false;
            foreach (float other in usedX)
            {
                if (Mathf.Abs(x - other) < _minSeparation)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose) return x;
            x = Random.Range(_minX, _maxX);
        }

        return x;
    }

    private void SpawnEnemy(float x)
    {
        Vector2 instantiatePosition = new(x, 6.16f);

        GameObject prefabToSpawn;

        int random = Random.Range(0, 3);
        if (random == 0)
            prefabToSpawn = _bear;
        else if (random == 1)
            prefabToSpawn = _seal;
        else
            prefabToSpawn = _wolf;

        if (prefabToSpawn == null) return;

        GameObject enemy = Instantiate(prefabToSpawn, instantiatePosition, Quaternion.identity);
        GameManager.Instance.Enemies.Add(enemy);
    }
}