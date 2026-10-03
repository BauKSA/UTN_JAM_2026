using Unity.VisualScripting;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    private Camera mainCamera_;
    private int penguinCount_ = 0;
    private readonly int maxPenguinCount_ = 5;

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (penguinCount_ >= maxPenguinCount_)
            {
                Debug.Log("Maximum number of penguins reached.");
                return;
            }
            
            Vector2 clickPosition = Input.mousePosition;
            Vector2 position = mainCamera_.ScreenToWorldPoint(clickPosition);

            if (!IsOnSpawnZone(position))
            {
                Debug.Log("Click position is outside the spawn zone.");
                return;
            }

            GameObject penguin = Instantiate(defenderPenguin_, position, Quaternion.identity);
            penguin.GetComponent<PenguinAliveController>().Destroyed += OnPenguinDestroyed;
            penguinCount_++;
            Debug.Log("Penguin spawned. Total penguins: " + penguinCount_);
        }
    }

    private void OnPenguinDestroyed()
    {
        penguinCount_--;
        Debug.Log("Penguin destroyed. Remaining penguins: " + penguinCount_);
    }

    private bool IsOnSpawnZone(Vector2 position)
    {
        BoxCollider2D spawnZoneCollider = spawnZone_.GetComponent<BoxCollider2D>();
        Debug.Log($"Checking if position {position} is within spawn zone bounds: {spawnZoneCollider.bounds}");

        return spawnZoneCollider.OverlapPoint(position);
    }
}
