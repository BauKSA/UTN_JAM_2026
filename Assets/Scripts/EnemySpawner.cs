using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _bear;
    [SerializeField]
    private GameObject _seal;
    [SerializeField]
    private GameObject _wolf;

    private float _spawnInterval = 12f;//7,75f antes. Le boore el "readonly"
    private float _timeSinceLastSpawn = -8f; //0f antes
    private int _enemiesSpawnead = 0;// Linea que agregué

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if(_timeSinceLastSpawn >= _spawnInterval)
        {
            //Agrego esto para que respawnen dos bichos en un minuto
            float timeSinceStart = Time.timeSinceLevelLoad;
            if (timeSinceStart < 60f && _enemiesSpawnead >= 2)
            {
                return;
            }
            
            SpawnEnemy();
            _enemiesSpawnead++; //Lineas que agregué
            _timeSinceLastSpawn = 0; // Cambie por: -= _spawnInterval
        }
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(-3.5f, 3.5f);
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

        // Codigo que habia cuando entre
        //GameObject enemy = Instantiate(_bear, instantiatePosition, Quaternion.identity);
        //GameManager.Instance.Enemies.Add(enemy);

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
