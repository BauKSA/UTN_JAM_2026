using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _bear;
    [SerializeField]
    private GameObject _seal;
    [SerializeField]
    private GameObject _wolf;

    private readonly float _spawnInterval = 7.75f;
    private float _timeSinceLastSpawn = 0f;

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if(_timeSinceLastSpawn >= _spawnInterval)
        {
            SpawnEnemy();
            _timeSinceLastSpawn -= _spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(-3.5f, 3.5f);
        Vector2 instantiatePosition = new(x, 6.16f);

        GameObject enemy = Instantiate(_bear, instantiatePosition, Quaternion.identity);
        GameManager.Instance.Enemies.Add(enemy);

        /*
        int enemy = Random.Range(0, 2);
        if (enemy == 0)
        {
            Instantiate(_bear, instantiatePosition, Quaternion.identity);
        }
        else if (enemy == 1)
        {
            Instantiate(_seal, instantiatePosition, Quaternion.identity);
        }
        else
        {
            Instantiate(_wolf, instantiatePosition, Quaternion.identity);
        }
        */
    }
}
